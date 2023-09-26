using XRPL.NET.Enums;

namespace XRPL.NET.Models;

public class XrplNetworkSettings
{
    public XrplNetworkSettings(uint networkId, XrplProtocol protocol, string? networkUrl = null)
    {
        NetworkId = networkId;
        Protocol = protocol;
        NetworkUrl = networkUrl;
    }

    public uint NetworkId { get; }
    public XrplProtocol Protocol { get; }
    public string? NetworkUrl { get; }
}
