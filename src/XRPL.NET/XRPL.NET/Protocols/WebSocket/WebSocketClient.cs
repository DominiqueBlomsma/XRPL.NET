using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using XRPL.NET.Exceptions;

namespace XRPL.NET.Protocols.WebSocket;

internal class WebSocketClient : WebSocketClientBase, IXrplProtocolClient
{
    private readonly ConcurrentDictionary<Guid, TaskCompletionSource<WebSocketResponse>>? _webSocketRequests = new();

    internal WebSocketClient(Uri uri, CancellationTokenSource cancellationTokenSource, ILogger logger) : base(uri, cancellationTokenSource, logger)
    {
    }

    public async Task<T> GetResponse<T>(string command, object? request, JsonSerializerOptions options, CancellationToken token)
    {
        try
        {
            var tcs = new TaskCompletionSource<WebSocketResponse>();

            var webSocketRequest = new WebSocketRequest(command, request);
            _webSocketRequests!.TryAdd(webSocketRequest.Id, tcs);
            await SendMessageAsync(webSocketRequest, token);

            var task = Task.Run(() => tcs.Task, token);
            var result = await task;

            if (result.Status == "error")
            {
                throw new XrplException(result.ErrorCode, result.Error, result.ErrorMessage ?? result.ErrorException);
            }

            var parsed = result.Result.Deserialize<T>(options)!;
            return parsed;
        }
        catch (OperationCanceledException ex)
        {   
            Logger?.LogTrace(ex, "Cancelled command {Command}.", command);
            throw;
        }
        catch (Exception ex)
        {
            Logger?.LogError(ex, "Failed to get WebSocket response of command {Command}.", command);
            throw;
        }
    }

    protected override void MessageReceived(WebSocketResponse webSocketResponse)
    {
        Logger?.LogTrace("Received message with ID: {ResponseId}.", webSocketResponse.Id);

        if (_webSocketRequests!.TryGetValue(webSocketResponse.Id, out var tcs))
        {
            tcs.SetResult(webSocketResponse);
        }
        else
        {
            // TODO: Implement missing request ID
        }
    }
}
