using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

public class ServerStateResponse
{
    [JsonPropertyName("state")]
    public State State { get; set; } = default!;
}
