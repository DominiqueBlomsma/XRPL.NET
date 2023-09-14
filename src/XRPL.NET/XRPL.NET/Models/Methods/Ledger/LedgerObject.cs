using System.Text.Json.Serialization;
using XRPL.NET.Converters;

namespace XRPL.NET.Models.Methods.Ledger;

public class LedgerObject
{
    [JsonPropertyName("accepted")]
    public bool Accepted { get; set; }

    /// <summary>
    /// Hash of all account state information in this ledger, as hex
    /// </summary>
    [JsonPropertyName("account_hash")]
    public string AccountHash { get; set; } = default!;

    /// <summary>
    /// A bit-map of <see href="https://xrpl.org/ledger-header.html#close-flags">flags relating to the closing of this ledger</see>.
    /// </summary>
    [JsonPropertyName("close_flags")]
    public int CloseFlags { get; set; }

    /// <summary>
    /// The time this ledger was closed.
    /// </summary>
    [JsonPropertyName("close_time")]
    public DateTime CloseTime { get; set; }

    /// <summary>
    /// The time this ledger was closed, in human-readable format. Always uses the UTC time zone.
    /// </summary>
    [JsonPropertyName("close_time_human")]
    public string CloseTimeHuman { get; set; } = default!;

    /// <summary>
    /// Ledger close times are rounded to within this many seconds.
    /// </summary>
    [JsonPropertyName("close_time_resolution")]
    public int CloseTimeResolution { get; set; }

    /// <summary>
    /// Whether or not this ledger has been closed
    /// </summary>
    [JsonPropertyName("closed")]
    public bool Closed { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; } = default!;

    /// <summary>
    /// Unique identifying hash of the entire ledger.
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    public string LedgerHash { get; set; } = default!;

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#ledger-index">Ledger Index</see> of this ledger, as a quoted integer
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public string LedgerIndex { get; set; } = default!;

    /// <summary>
    /// The time at which the previous ledger was closed.
    /// </summary>
    [JsonPropertyName("parent_close_time")]
    public int ParentCloseTime { get; set; }

    /// <summary>
    /// Unique identifying hash of the ledger that came immediately before this one.
    /// </summary>
    [JsonPropertyName("parent_hash")]
    public string ParentHash { get; set; } = default!;

    [JsonPropertyName("seqNum")]
    public string SequenceNumber { get; set; } = default!;

    /// <summary>
    /// Total number of XRP drops in the network, as a quoted integer. (This decreases as transaction costs destroy XRP.)
    /// </summary>
    [JsonPropertyName("total_coins")]
    public string TotalCoins { get; set; } = default!;

    /// <summary>
    /// Hash of the transaction information included in this ledger, as hex
    /// </summary>
    [JsonPropertyName("transaction_hash")]
    public string TransactionHash { get; set; } = default!;

    /// <summary>
    /// Omitted unless requested) Transactions applied in this ledger version.
    /// By default, members are the transactions' identifying <see href="https://xrpl.org/basic-data-types.html#hashes">Hash</see> strings. If the request specified expand as true, members are full representations of the transactions instead,
    /// in either JSON or binary depending on whether the request specified binary as true.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<LedgerTransaction>? Transactions { get; set; }
}
