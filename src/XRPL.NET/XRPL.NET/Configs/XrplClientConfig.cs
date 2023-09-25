using XRPL.NET.Enums;

namespace XRPL.NET.Configs;

public class XrplClientConfig
{
    public const string SectionKey = "XrplClient";

    public Dictionary<string, XrplClientNetworkConfig>? Networks { get; set; }

    public string? GetNetworkUrl(int networkId, XrplProtocol protocol)
    {
        string? url = null;

        if (Networks?.TryGetValue(networkId.ToString(), out var networkConfig) ?? false)
        {
            url = protocol switch
            {
                XrplProtocol.JsonRpc => networkConfig.JsonRpcUrl,
                XrplProtocol.WebSocket => networkConfig.WebSocketUrl,
                _ => throw new ArgumentOutOfRangeException(nameof(protocol), protocol, $"Unknown XRPL protocol: {protocol}")
            };
        }

        return url;
    }
}
