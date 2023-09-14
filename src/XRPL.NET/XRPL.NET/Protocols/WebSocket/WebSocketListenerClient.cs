using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using XRPL.NET.Exceptions;

namespace XRPL.NET.Protocols.WebSocket;

internal class WebSocketListenerClient : WebSocketClientBase
{
    private readonly ConcurrentQueue<TaskCompletionSource<WebSocketResponse>> _webSocketRequests = new();

    internal WebSocketListenerClient(Uri uri, CancellationTokenSource cancellationTokenSource, ILogger logger) : base(uri, cancellationTokenSource, logger)
    {
    }

    public async IAsyncEnumerable<WebSocketResponse> GetResponses(string command, object? request, [EnumeratorCancellation] CancellationToken token)
    {
        var tcs = new TaskCompletionSource<WebSocketResponse>();

        try
        {
            var webSocketRequest = new WebSocketRequest(command, request);
            _webSocketRequests.Enqueue(tcs);
            await SendMessageAsync(webSocketRequest, token);
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

        while (true)
        {
            // Wait for either the TaskCompletionSource to complete or the CancellationToken to be cancelled
            await Task.WhenAny(tcs.Task, Task.Delay(-1, token));

            if (token.IsCancellationRequested)
            {
                yield break;
            }

            var result = await tcs.Task;

            if (result.Status == "error") 
            {
                throw new XrplException(result.ErrorCode, result.Error, result.ErrorMessage);
            }

            tcs = new TaskCompletionSource<WebSocketResponse>();
            _webSocketRequests.Enqueue(tcs);
            yield return result;
        }
    }

    protected override void MessageReceived(WebSocketResponse webSocketResponse)
    {
        Logger?.LogTrace("Received message with ID: {ResponseId}.", webSocketResponse.Id);
        if (_webSocketRequests.TryDequeue(out var tcs))
        {
            // Set the result of the TaskCompletionSource
            tcs.SetResult(webSocketResponse);
        }
    }
}
