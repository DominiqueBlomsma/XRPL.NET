using XRPL.NET.Enums;

namespace XRPL.NET.Models;

public class XrplWebSocketSettings : XrplNetworkSettings
{
    public XrplWebSocketSettings(uint networkId, string? networkUrl = null) : base(networkId, XrplProtocol.WebSocket, networkUrl)
    {
        
    }
}
