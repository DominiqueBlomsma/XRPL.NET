using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using XRPL.NET.Exceptions;
using XRPL.NET.Helpers;

namespace XRPL.NET.Protocols.JsonRpc;

internal class JsonRpcClient : IXrplProtocolClient
{
    private readonly Uri _uri;
    private readonly ILogger? _logger;

    public JsonRpcClient(Uri uri, ILogger? logger)
    {
        _uri = uri;
        _logger = logger;
    }

    public async Task<T> GetResponse<T>(string command, object? request, JsonSerializerOptions options, CancellationToken token)
    {
        try
        {
            var jsonRpcRequest = new JsonRpcRequest(command, request);
            using var httpClient = new HttpClient();
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _uri);

            var json = JsonSerializer.Serialize(jsonRpcRequest, XrplJsonHelper.SerializerOptions);
            requestMessage.Content = new StringContent(json, Encoding.UTF8, XrplJsonHelper.MediaType);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(XrplJsonHelper.MediaType);

            using var response = await httpClient.SendAsync(requestMessage, token);
            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync(token);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with response \"{responseText}\"", null, response.StatusCode);
            }

            var result = JsonSerializer.Deserialize<JsonRpcResponse>(responseText, XrplJsonHelper.SerializerOptions);
            if (result?.Result == null)
            {
                throw new Exception($"Unable to deserialize response \"{responseText}\" to type \"{typeof(T).Name}\"");
            }

            if (result.Result.Status == "error")
            {
                throw new XrplException(result.Result.ErrorCode, result.Result.Error, result.Result.ErrorMessage ?? result.Result.ErrorException);
            }

            var parsed = result.Result.Data.Deserialize<T>(options)!;
            return parsed;
        }
        catch (XrplException ex)
        {
            _logger?.LogTrace(ex, "Command {Command} resulted in error {Error} with code {ErrorCode}.", command, ex.Error, ex.ErrorCode);
            throw;
        }
        catch (OperationCanceledException ex)
        {
            _logger?.LogTrace(ex, "Cancelled command {Command}.", command);
            throw;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to get WebSocket response of command {Command}.", command);
            throw;
        }
    }

    public void Dispose()
    {
    }
}
