using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Ledger;

public class LedgerResponse
{
    /// <summary>
    /// The complete header data of this ledger.
    /// </summary>
    [JsonPropertyName("ledger")]
    public LedgerObject Ledger { get; set; } = default!;

    /// <summary>
    /// Unique identifying hash of the entire ledger.
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    public string LedgerHash { get; set; } = default!;

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#ledger-index">Ledger Index</see> of this ledger
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public uint LedgerIndex { get; set; }

    /// <summary>
    /// (May be omitted) If true, this is a validated ledger version. If omitted or set to false, this ledger's data is not final.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool? Validated { get; set; }
}
