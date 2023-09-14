using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Helpers;

namespace XRPL.NET.Protocols.JsonRpc;

public class JsonRpcRequest
{
    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonPropertyName("params")]
    public List<Dictionary<string, object>> Params { get; set; } = new();

    public JsonRpcRequest(string method, object? request)
    {
        Method = method;

        if (request != null)
        {
            var json = JsonSerializer.Serialize(request, XrplJsonHelper.SerializerOptions);
            Params = new List<Dictionary<string, object>> { JsonSerializer.Deserialize<Dictionary<string, object>>(json)! };
        }
    }
}
