using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_lines.html#response-format
/// </summary>
public class AccountLinesResponse : IPaginationMarker
{
    /// <summary>
    /// Unique <see href="https://xrpl.org/basic-data-types.html#addresses">Address</see> of the account this request corresponds to. This is the "perspective account" for purpose of the trust lines.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// Array of trust line objects, as described below. If the number of trust lines is large, only returns up to the limit at a time.
    /// </summary>
    [JsonPropertyName("lines")]
    public List<AccountTrustLine> TrustLines { get; set; } = default!;

    /// <summary>
    /// (Omitted if <see cref="LedgerHash"/> or <see cref="LedgerIndex"/> provided) The ledger index of the current open ledger, which was used when retrieving this information.
    /// </summary>
    [JsonPropertyName("ledger_current_index")]
    public uint? LedgerCurrentIndex { get; set; }

    /// <summary>
    /// (Omitted if <see cref="LedgerCurrentIndex"/> provided instead) The ledger index of the ledger version that was used when retrieving this data.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public uint? LedgerIndex { get; set; }

    /// <summary>
    /// (May be omitted) The identifying hash the ledger version that was used when retrieving this data. 
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    public string? LedgerHash { get; set; }

    /// <summary>
    /// Server-defined value indicating the response is paginated. Pass this to the next call to resume where this call left off. Omitted when there are no additional pages after this one.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
}
