using XRPL.NET.Enums;

namespace XRPL.NET.Models;

public class XrplNetworkSettings
{
    public XrplNetworkSettings(int networkId, XrplProtocol protocol, string? networkUrl = null)
    {
        NetworkId = networkId;
        Protocol = protocol;
        NetworkUrl = networkUrl;
    }

    public int NetworkId { get; }
    public XrplProtocol Protocol { get; }
    public string? NetworkUrl { get; }
}
