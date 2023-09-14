namespace XRPL.NET.Configs;

public class XrplClientConfig
{
    public const string SectionKey = "XrplClient";

    public string? WebSocketUrl { get; set; }
    public string? JsonRpcUrl { get; set; }

    public Uri WebSocketUri => !string.IsNullOrWhiteSpace(WebSocketUrl) ? new Uri(WebSocketUrl) : throw new ArgumentException($"Missing {nameof(WebSocketUrl)} in the {SectionKey} section");
    public Uri JsonRpcUri => !string.IsNullOrWhiteSpace(JsonRpcUrl) ? new Uri(JsonRpcUrl) : throw new ArgumentException($"Missing {nameof(JsonRpcUrl)} in the {SectionKey} section");
}
