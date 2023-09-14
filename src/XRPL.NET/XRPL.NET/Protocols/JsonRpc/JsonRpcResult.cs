using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace XRPL.NET.Protocols.JsonRpc;

public class JsonRpcResult
{
    /// <summary>
    /// The value success indicates the request was successfully received and understood by the server.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("error_exception")]
    public string? ErrorException { get; set; }

    [JsonExtensionData]
    public JsonObject? Data { get; set; }
}
