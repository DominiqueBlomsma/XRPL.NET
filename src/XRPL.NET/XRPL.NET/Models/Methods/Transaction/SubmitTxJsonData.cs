using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

public class SubmitTxJsonData
{
    [JsonPropertyName("InvoiceID")]
    public string? InvoiceId { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; } = default!;
}
