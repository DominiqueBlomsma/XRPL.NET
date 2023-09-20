using XRPL.NET.Enums;

namespace XRPL.NET.Models;

public class XrplNetworkSettings
{
    public XrplNetworkSettings(string networkKey, XrplProtocol protocol, string? networkUrl = null)
    {
        NetworkKey = networkKey;
        Protocol = protocol;
        NetworkUrl = networkUrl;
        ClientKey = $"{networkKey}-{protocol}";
    }

    public string NetworkKey { get; }
    public XrplProtocol Protocol { get; }
    public string? NetworkUrl { get; }

    internal string ClientKey { get; }
}
