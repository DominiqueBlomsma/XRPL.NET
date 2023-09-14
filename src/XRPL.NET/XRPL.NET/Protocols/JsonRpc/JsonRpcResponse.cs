using System.Text.Json.Serialization;

namespace XRPL.NET.Protocols.JsonRpc;

public class JsonRpcResponse
{
    /// <summary>
    /// The result of the query; contents vary depending on the command.
    /// </summary>
    [JsonPropertyName("result")]
    public JsonRpcResult Result { get; set; } = default!;
}
