using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

public class FeeRequest
{
    [JsonPropertyName("tx_blob")]
    public string? TxBlob { get; set; }
}
