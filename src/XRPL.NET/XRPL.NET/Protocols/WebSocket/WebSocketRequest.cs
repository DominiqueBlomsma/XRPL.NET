using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Helpers;

namespace XRPL.NET.Protocols.WebSocket;

public class WebSocketRequest
{
    public WebSocketRequest(string command, object? request)
    {
        Id = Guid.NewGuid();
        Command = command;

        if (request != null)
        {
            RequestValues = JsonSerializer.SerializeToDocument(request, XrplJsonHelper.SerializerOptions).Deserialize<Dictionary<string, object>>() ??
                            throw new InvalidOperationException($"Unable to serialize {command} request");
        }
    }

    /// <summary>
    /// A unique value to identify this request. The response to this request uses the same id field.
    /// This way, even if responses arrive out of order, you know which request prompted which response.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; }

    /// <summary>
    /// The name of the <see href="https://xrpl.org/public-api-methods.html">API method</see>.
    /// </summary>
    [JsonPropertyName("command")]
    public string Command { get; set; }

    /// <summary>
    /// (Optional) The API version to use. If omitted, use version 1.
    /// For details, see <see href="https://xrpl.org/request-formatting.html#api-versioning">API Versioning</see>.
    /// </summary>
    [JsonPropertyName("api_version")]
    public int? ApiVersion { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object>? RequestValues { get; set; }
}
