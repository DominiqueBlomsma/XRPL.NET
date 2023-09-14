using System.Text.Json.Serialization;
using XRPL.NET.Converters;
using XRPL.NET.Models.LedgerObjectTypes;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_objects.html#response-format
/// </summary>
public class AccountObjectsResponse : IPaginationMarker
{
    /// <summary>
    /// Unique <see href="https://xrpl.org/basic-data-types.html#addresses">Address</see> of the account this request corresponds to
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// (Array of objects owned by this account.
    /// </summary>
    [JsonPropertyName("account_objects")]
    public List<LedgerObjectBase> AccountObjects { get; set; } = default!;

    /// <summary>
    /// (Omitted if <see cref="LedgerHash"/> or <see cref="LedgerIndex"/> provided) The ledger index of the current open ledger, which was used when retrieving this information.
    /// </summary>
    [JsonPropertyName("ledger_current_index")]
    public uint? LedgerCurrentIndex { get; set; }

    /// <summary>
    /// (May be omitted) The ledger index of the ledger version that was used to generate this response.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public uint? LedgerIndex { get; set; }

    /// <summary>
    /// (May be omitted) The identifying hash of the ledger that was used to generate this response.
    /// </summary>
    [JsonPropertyName("ledger_hash")]
    public string? LedgerHash { get; set; }

    /// <summary>
    /// (May be omitted) The limit that was used in this request, if any.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Server-defined value indicating the response is paginated. Pass this to the next call to resume where this call left off. Omitted when there are no additional pages after this one.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }

    /// <summary>
    /// If included and set to true, the information in this response comes from a validated ledger version. Otherwise, the information is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool? Validated { get; set; }
}
