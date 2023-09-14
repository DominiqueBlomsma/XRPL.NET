using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_objects.html#request-format
/// </summary>
public class AccountObjectsRequest : LedgerRequestBase, IPaginationMarker
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's <see href="https://xrpl.org/basic-data-types.html#addresses">xAddress</see>.
    /// </summary>
    [Required]
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// If true, the response only includes objects that would block this account from <see href="https://xrpl.org/accounts.html#deletion-of-accounts">being deleted</see>.
    /// The default is false.
    /// </summary>
    [JsonPropertyName("deletion_blockers_only")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DeletionBlockersOnly { get; set; }

    /// <summary>
    /// The maximum number of objects to include in the results.
    /// Must be within the inclusive range 10 to 400 on non-admin connections. The default is 200.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Value from a previous paginated response.
    /// Resume retrieving data where that response left off.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }

    /// <summary>
    /// Filter results by a ledger entry type.
    /// The valid types are: check, deposit_preauth, escrow, nft_offer, offer, payment_channel, signer_list, state (trust line), and ticket.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
