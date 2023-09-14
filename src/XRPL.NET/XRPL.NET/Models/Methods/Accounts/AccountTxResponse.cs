using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_tx.html#response-format
/// </summary>
public class AccountTxResponse : IPaginationMarker
{
    /// <summary>
    /// Unique <see href="https://xrpl.org/basic-data-types.html#addresses">Address</see> identifying the related account.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// The ledger index of the earliest ledger actually searched for transactions.
    /// </summary>
    [JsonPropertyName("ledger_index_min")]
    public int LedgerIndexMin { get; set; }

    /// <summary>
    /// The ledger index of the most recent ledger actually searched for transactions.
    /// </summary>
    [JsonPropertyName("ledger_index_max")]
    public int LedgerIndexMax { get; set; }

    /// <summary>
    /// The limit value used in the request. (This may differ from the actual limit value enforced by the server.)
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    /// <summary>
    /// Server-defined value indicating the response is paginated. Pass this to the next call to resume where this call left off. Omitted when there are no additional pages after this one.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }

    /// <summary>
    /// Array of transactions matching the request's criteria, as explained below.
    /// </summary>
    [JsonPropertyName("transactions")]
    public List<AccountTxTransaction> Transactions { get; set; } = default!;

    /// <summary>
    /// If included and set to true, the information in this response comes from a validated ledger version. Otherwise, the information is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool? Validated { get; set; }
}
