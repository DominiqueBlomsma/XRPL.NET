using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_info.html#request-format
/// </summary>
public class AccountInfoRequest : LedgerRequestBase
{
    /// <summary>
    /// The account_info command retrieves information about an account, its activity, and its XRP balance.
    /// All information retrieved is relative to a particular version of the ledger.
    /// </summary>
    /// <param name="account">A unique identifier for the account, most commonly the account's Address.</param>
    public AccountInfoRequest(string account)
    {
        Account = account;
    }

    /// <summary>
    /// A unique identifier for the account, most commonly the account's Address.
    /// </summary>
    [Required]
    [JsonPropertyName("account")]
    public string Account { get; set; }

    /// <summary>
    /// (Optional) If true, and the FeeEscalation amendment is enabled, also returns stats about queued transactions associated with this account.
    /// Can only be used when querying for the data from the current open ledger.
    /// </summary>
    [JsonPropertyName("queue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Queue { get; set; }

    /// <summary>
    /// (Optional) If true, and the MultiSign amendment is enabled, also returns any SignerList objects associated with this account.
    /// </summary>
    [JsonPropertyName("signer_lists")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SignerLists { get; set; }

    /// <summary>
    /// (Optional) If true, then the account field only accepts a public key or XRP Ledger address.
    /// Otherwise, account can be a secret or passphrase (not recommended). The default is false.
    /// </summary>
    [JsonPropertyName("strict")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Strict { get; set; }
}
