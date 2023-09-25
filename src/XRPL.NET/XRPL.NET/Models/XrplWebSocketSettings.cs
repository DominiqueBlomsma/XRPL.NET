using XRPL.NET.Enums;

namespace XRPL.NET.Models;

public class XrplWebSocketSettings : XrplNetworkSettings
{
    public XrplWebSocketSettings(int networkId, string? networkUrl = null) : base(networkId, XrplProtocol.WebSocket, networkUrl)
    {
        
    }
}
