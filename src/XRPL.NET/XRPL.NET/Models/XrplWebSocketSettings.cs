using XRPL.NET.Enums;

namespace XRPL.NET.Models;

public class XrplWebSocketSettings : XrplNetworkSettings
{
    public XrplWebSocketSettings(string networkKey, string? networkUrl = null) : base(networkKey, XrplProtocol.WebSocket, networkUrl)
    {
        
    }
}
