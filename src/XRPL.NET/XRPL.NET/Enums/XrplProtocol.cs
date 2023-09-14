namespace XRPL.NET.Enums;

public enum XrplProtocol
{
    /// <summary>
    /// JSON-RPC uses individual HTTP requests and responses for each call, similar to a RESTful API. 
    /// </summary>
    JsonRpc,

    /// <summary>
    /// WebSocket uses a persistent connection that allows the server to push data to the client. Functions that require push messages, like event subscriptions, are only available using WebSocket.
    /// </summary>
    WebSocket
}
