using System.Text.Json.Serialization;

namespace XRPL.NET.BinaryCodec.Models;

public class Definitions
{
    [JsonPropertyName("TYPES")]
    public Dictionary<string, int> Types { get; set; } = default!;

    [JsonPropertyName("LEDGER_ENTRY_TYPES")]
    public Dictionary<string, int> LedgerEntryTypes { get; set; } = default!;

    [JsonPropertyName("FIELDS")]
    public List<FieldElement> Fields { get; set; } = default!;

    [JsonPropertyName("TRANSACTION_RESULTS")]
    public Dictionary<string, int> TransactionResults { get; set; } = default!;

    [JsonPropertyName("TRANSACTION_TYPES")]
    public Dictionary<string, int> TransactionTypes { get; set; } = default!;
}
