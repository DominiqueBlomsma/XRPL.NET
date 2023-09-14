using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Ledger;

/// <summary>
/// The ledger_entry method returns a single ledger object from the XRP Ledger in its raw format. See ledger format for information on the different types of objects you can retrieve.
/// https://xrpl.org/ledger_entry.html#request-format
/// </summary>
public class LedgerEntryRequest : LedgerRequestBase
{
    /// <summary>
    /// The <see href="https://xrpl.org/ledger-object-ids.html">object ID</see> of a single object to retrieve from the ledger, as a 64-character (256-bit) hexadecimal string.
    /// </summary>
    [JsonPropertyName("index")]
    public string? Index { get; set; }

    /// <summary>
    /// The classic address of the <see href="https://xrpl.org/accountroot.html">AccountRoot object</see> to retrieve.
    /// </summary>
    [JsonPropertyName("account_root")]
    public string? AccountRoot { get; set; }

    /// <summary>
    /// Retrieve a <see href="https://xrpl.org/ripplestate.html">RippleState object</see>, which tracks a (non-XRP) currency balance between two accounts.
    /// </summary>
    [JsonPropertyName("ripple_state")]
    public LedgerEntryRippleState? RippleState { get; set; }

    // TODO: directory, offer,  check, escrow, payment_channel, deposit_preauth, ticket
}
