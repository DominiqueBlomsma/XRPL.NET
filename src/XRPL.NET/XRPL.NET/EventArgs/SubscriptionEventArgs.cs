using XRPL.NET.Protocols.WebSocket;

namespace XRPL.NET.EventArgs;

public class SubscriptionEventArgs
{
    public WebSocketResponse Response { get; set; } = default!;
}
