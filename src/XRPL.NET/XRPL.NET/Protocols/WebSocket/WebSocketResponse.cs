using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace XRPL.NET.Protocols.WebSocket;

public class WebSocketResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("result")]
    public JsonObject? Result { get; set; }

    [JsonExtensionData]
    public JsonObject? Data { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("error_code")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("error_exception")]
    public string? ErrorException { get; set; }
}
