using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_tx.html#request-format
/// </summary>
public class AccountTxRequest : LedgerRequestBase, IPaginationMarker
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's <see href="https://xrpl.org/basic-data-types.html#addresses">xAddress</see>.
    /// </summary>
    [Required]
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// (Optional) Use to specify the earliest ledger to include transactions from.
    /// A value of -1 instructs the server to use the earliest validated ledger version available.
    /// </summary>
    [JsonPropertyName("ledger_index_min")]
    public int? LedgerIndexMin { get; set; }

    /// <summary>
    /// (Optional) Use to specify the most recent ledger to include transactions from.
    /// A value of -1 instructs the server to use the most recent validated ledger version available.
    /// </summary>
    [JsonPropertyName("ledger_index_max")]
    public int? LedgerIndexMax { get; set; }

    /// <summary>
    /// (Optional) Defaults to false.
    /// If set to true, returns transactions as hex strings instead of JSON.
    /// </summary>
    [JsonPropertyName("binary")]
    public bool? Binary { get; set; }

    /// <summary>
    /// (Optional) Defaults to false. If set to true, returns values indexed with the oldest ledger first.
    /// Otherwise, the results are indexed with the newest ledger first.
    /// (Each page of results may not be internally ordered, but the pages are overall ordered.)
    /// </summary>
    [JsonPropertyName("forward")]
    public bool? Forward { get; set; }

    /// <summary>
    /// (Optional) Default varies. Limit the number of transactions to retrieve. The server is not required to honor this value.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Value from a previous paginated response. Resume retrieving data where that response left off.
    /// This value is stable even if there is a change in the server's range of available ledgers.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
}
