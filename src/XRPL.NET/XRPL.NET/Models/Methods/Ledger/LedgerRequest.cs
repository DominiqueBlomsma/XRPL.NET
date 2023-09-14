using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Ledger;

public class LedgerRequest : LedgerRequestBase
{
    /// <summary>
    /// Admin only If true, return full information on the entire ledger. Ignored if you did not specify a ledger version.
    /// The default is false. (Equivalent to enabling transactions, accounts, and expand.) The <see href="https://xrpl.org/the-clio-server.html">Clio server</see> does not support this field.
    /// Caution: On Mainnet, this can be gigabytes worth of data, so the request is likely to time out.
    /// </summary>
    [JsonPropertyName("full")]
    public bool? Full { get; set; }

    /// <summary>
    /// Admin only. If true, return the ledger's entire state data. Ignored if you did not specify a ledger version.
    /// The default is false. Caution: On Mainnet, this can be gigabytes worth of data, so the request is likely to time out.
    /// Use <see href="https://xrpl.org/ledger_data.html">ledger_data</see> instead to fetch state data across multiple paginated requests.
    /// </summary>
    [JsonPropertyName("accounts")]
    public bool? Accounts { get; set; }

    /// <summary>
    /// If true, return information on transactions in the specified ledger version. The default is false. Ignored if you did not specify a ledger version.
    /// </summary>
    [JsonPropertyName("transactions")]
    public bool? Transactions { get; set; }

    /// <summary>
    /// Provide full JSON-formatted information for transaction/account information instead of only hashes. The default is false. Ignored unless you request transactions, accounts, or both.
    /// </summary>
    [JsonPropertyName("expand")]
    public bool? Expand { get; set; }

    /// <summary>
    /// If true, include owner_funds field in the metadata of OfferCreate transactions in the response. The default is false. Ignored unless transactions are included and expand is true.
    /// </summary>
    [JsonPropertyName("owner_funds")]
    public bool? OwnerFunds { get; set; }

    /// <summary>
    /// If true, and transactions and expand are both also true, return transaction information in binary format (hexadecimal string) instead of JSON format.
    /// </summary>
    [JsonPropertyName("binary")]
    public bool? Binary { get; set; }

    /// <summary>
    /// If true, and the command is requesting the current ledger, includes an array of <see href="https://xrpl.org/transaction-cost.html#queued-transactions">queued transactions</see> in the results.
    /// </summary>
    [JsonPropertyName("queue")]
    public bool? Queue { get; set; }

    /// <summary>
    /// Filter by a ledger entry type.
    /// The valid types are: account, amendments, amm, check, deposit_preauth, directory, escrow, fee, hashes, nft_offer, offer, payment_channel, signer_list, state (trust line), and ticket.
    /// Ignored unless you request accounts (state data).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
