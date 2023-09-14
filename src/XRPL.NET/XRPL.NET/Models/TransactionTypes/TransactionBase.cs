using System.Text.Json.Serialization;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// Every transaction has the same set of common fields, plus additional fields based on the <see href="https://xrpl.org/transaction-types.html">transaction type</see>. 
/// https://xrpl.org/transaction-common-fields.html
/// </summary>
public class TransactionBase
{
    /// <summary>
    /// (Required) The unique address of the <see href="https://xrpl.org/accounts.html">account</see> that initiated the transaction.
    /// </summary>
    [JsonPropertyName("Account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// (Required) The type of transaction. 
    /// </summary>
    [JsonPropertyName("TransactionType")]
    public string TransactionType { get; set; } = default!;

    /// <summary>
    /// (Required; <see href="https://xrpl.org/transaction-common-fields.html#auto-fillable-fields">auto-fillable</see>) Integer amount of XRP, in drops, to be destroyed as a cost for distributing this transaction to the network.
    /// Some transaction types have different minimum requirements.
    /// See <see href="https://xrpl.org/transaction-cost.html">Transaction Cost</see> for details.
    /// </summary>
    [JsonPropertyName("Fee")]
    public string Fee { get; set; } = default!;

    /// <summary>
    /// (Required; <see href="https://xrpl.org/transaction-common-fields.html#auto-fillable-fields">auto-fillable</see>) The <see href="https://xrpl.org/basic-data-types.html#account-sequence">sequence number</see> of the account sending the transaction.
    /// A transaction is only valid if the Sequence number is exactly 1 greater than the previous transaction from the same account.
    /// The special case 0 means the transaction is using a <see href="https://xrpl.org/tickets.html">Ticket</see> instead,
    /// </summary>
    [JsonPropertyName("Sequence")]
    public uint? Sequence { get; set; }

    [JsonPropertyName("NetworkID")]
    public uint? NetworkId { get; set; }

    /// <summary>
    /// (Automatically added when signing) Hex representation of the public key that corresponds to the private key used to sign this transaction.
    /// If an empty string, indicates a multi-signature is present in the Signers field instead.
    /// </summary>
    [JsonPropertyName("SigningPubKey")]
    public string? SigningPublicKey { get; set; }

    /// <summary>
    /// An identifying hash value unique to this transaction, as a hex string.
    /// This information is added to Transactions in request responses, but is not part of the canonical Transaction information on ledger.
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    // TODO: Add all Common Fields https://xrpl.org/transaction-common-fields.html
}
