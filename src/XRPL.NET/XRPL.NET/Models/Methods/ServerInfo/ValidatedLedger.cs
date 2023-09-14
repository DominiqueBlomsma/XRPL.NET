using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

public class ValidatedLedger
{
    /// <summary>
    /// Base fee, in drops of XRP, for propagating a transaction to the network.
    /// </summary>
    [JsonPropertyName("base_fee")]
    public int BaseFee { get; set; }

    /// <summary>
    /// Time this ledger was closed, in seconds since the Ripple Epoch.
    /// </summary>
    [JsonPropertyName("close_time")]
    public DateTime CloseTime { get; set; }

    /// <summary>
    /// Unique hash of this ledger version, as hexadecimal.
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; set; } = default!;

    /// <summary>
    /// The minimum <see href="https://xrpl.org/reserves.html">account reserve</see>, as of the most recent validated ledger version.
    /// </summary>
    [JsonPropertyName("reserve_base")]
    public int ReserveBase { get; set; }

    /// <summary>
    /// The <see href="https://xrpl.org/reserves.html">owner reserve</see> for each item an account owns, as of the most recent validated ledger version.
    /// </summary>
    [JsonPropertyName("reserve_inc")]
    public int ReserveInc { get; set; }

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#ledger-index">ledger index</see> of the most recently validated ledger version.
    /// </summary>
    [JsonPropertyName("seq")]
    public int Seq { get; set; }
}
