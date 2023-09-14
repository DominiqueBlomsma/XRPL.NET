using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

/// <summary>
/// Response expected from an <see cref="FeeRequest"/>.
/// </summary>
public class FeeResponse
{
    [JsonPropertyName("drops")]
    public FeeDrops Drops { get; set; } = default!;

    /// <summary>
    /// The ledger index of the current in-progress ledger, which was used when retrieving this information.
    /// </summary>
    [JsonPropertyName("ledger_current_index")]
    public int LedgerCurrentIndex { get; set; }

    /// <summary>
    /// True if this data is from a validated ledger version;<br/>
    /// if omitted or set to false, this data is not final.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
}
