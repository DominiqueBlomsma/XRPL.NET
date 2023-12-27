using System.Net.WebSockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using XRPL.NET.Helpers;

namespace XRPL.NET.Protocols.WebSocket;

internal abstract class WebSocketClientBase : IDisposable
{
    private readonly SemaphoreSlim? _semaphoreSlim = new(1, 1);
    private readonly ManualResetEventSlim _manualResetEventSlim = new(false);

    protected ClientWebSocket? ClientWebSocket;
    private const int ChunkSize = 1024;
    protected readonly Uri Uri;
    protected readonly ILogger? Logger;
    protected readonly CancellationTokenSource CancellationTokenSource;

    internal WebSocketClientBase(Uri uri, CancellationTokenSource cancellationTokenSource, ILogger? logger)
    {
        Uri = uri;
        CancellationTokenSource = cancellationTokenSource;
        Logger = logger;
    }
    protected abstract void MessageReceived(WebSocketResponse webSocketResponse);

    protected async Task SendMessageAsync(object request, CancellationToken token)
    {
        try
        {
            await EnsureWebSocketOpenState(token);

            var message = JsonSerializer.SerializeToUtf8Bytes(request, XrplJsonHelper.SerializerOptions);
            var messagesCount = (int)Math.Ceiling((double)message.Length / ChunkSize);

            for (var i = 0; i < messagesCount; i++)
            {
                var offset = ChunkSize * i;
                var count = ChunkSize;
                var lastMessage = i + 1 == messagesCount;

                if (count * (i + 1) > message.Length)
                {
                    count = message.Length - offset;
                }

                await ClientWebSocket!.SendAsync(new ArraySegment<byte>(message, offset, count), WebSocketMessageType.Text, lastMessage, token);
            }
        }
        catch (OperationCanceledException ex)
        {
            Logger?.LogInformation(ex, "Cancelled operation before sending message: {@Request}", request);
        }
        catch (Exception ex)
        {
            Logger?.LogError(ex, "Failed to send message: {@Request}", request);
            throw;
        }
    }

    private async Task EnsureWebSocketOpenState(CancellationToken token)
    {
        if (ClientWebSocket == null)
        {
            await _semaphoreSlim!.WaitAsync(token);
            try
            {
                if (ClientWebSocket == null)
                {
                    ClientWebSocket = new ClientWebSocket();
                    ClientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);
                    _manualResetEventSlim.Reset();
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        if (ClientWebSocket.State == WebSocketState.Connecting)
        {
            await Task.Run(() => _manualResetEventSlim.Wait(token), token);
        }

        if (ClientWebSocket.State == WebSocketState.Closed || ClientWebSocket.State == WebSocketState.Aborted ||
            ClientWebSocket.State == WebSocketState.CloseReceived || ClientWebSocket.State == WebSocketState.CloseSent)
        {
            await ReconnectWebSocketAsync(token);
        }
        else if (ClientWebSocket.State != WebSocketState.Open && ClientWebSocket.State != WebSocketState.Connecting)
        {
            await _semaphoreSlim!.WaitAsync(token);
            try
            {
                if (ClientWebSocket.State != WebSocketState.Open && ClientWebSocket.State != WebSocketState.Connecting)
                {
                    Logger?.LogInformation("Start connecting to \"{WebSocketUri}\", with current state: {State}", Uri, ClientWebSocket.State);

                    await ClientWebSocket.ConnectAsync(Uri, CancellationTokenSource.Token);
                    StartReceivingAsync();
                }
            }
            finally
            {
                _manualResetEventSlim.Set();
                _semaphoreSlim!.Release();
            }
        }
    }

    private async Task ReconnectWebSocketAsync(CancellationToken token)
    {
        await _semaphoreSlim!.WaitAsync(token);

        try
        {
            ClientWebSocket?.Dispose();
            ClientWebSocket = new ClientWebSocket();
            ClientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);

            Logger?.LogInformation("Reconnecting to \"{WebSocketUri}\", with current state: {State}", Uri, ClientWebSocket.State);

            await ClientWebSocket.ConnectAsync(Uri, CancellationTokenSource.Token);
            StartReceivingAsync();
        }
        finally
        {
            _semaphoreSlim!.Release();
        }
    }

    private async void StartReceivingAsync()
    {
        if (ClientWebSocket?.State != WebSocketState.Open)
        {
            throw new InvalidOperationException("WebSocket state is not open");
        }

        Logger?.LogInformation("Start of receiving WebSocket messages.");

        var buffer = new ArraySegment<byte>(new byte[1024]);
        while (ClientWebSocket.State == WebSocketState.Open && !CancellationTokenSource.IsCancellationRequested)
        {
            await using var ms = new MemoryStream();

            try
            {
                WebSocketReceiveResult? result;
                do
                {
                    result = await ClientWebSocket.ReceiveAsync(buffer, CancellationTokenSource.Token);
                    ms.Write(buffer.Array!, buffer.Offset, result.Count);
                } while (!result.EndOfMessage && !CancellationTokenSource.Token.IsCancellationRequested);
            }
            catch (OperationCanceledException ex)
            {
                Logger?.LogTrace(ex, "Stopped receiving messages of the websocket.");
                break;
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, "An error occurred while receiving websocket data.");
                break;
            }

            if (ClientWebSocket.State == WebSocketState.Open && !CancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    var response = JsonSerializer.Deserialize<WebSocketResponse>(ms)!;
                    MessageReceived(response);
                }
                catch (Exception ex)
                {
                    Logger?.LogInformation(ex, "An error occurred while deserializing message.");
                    break;
                }
            }
        }
    }

    public async Task CloseAsync()
    {
        if (ClientWebSocket?.State == WebSocketState.Open)
        {
            await ClientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by the client", CancellationToken.None);
        }
    }

    public void Dispose()
    {
        ClientWebSocket?.Dispose();
    }
}
