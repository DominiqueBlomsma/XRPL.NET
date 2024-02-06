using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// The response follows the <see href="https://xrpl.org/response-formatting.html">standard format</see>, with a successful result containing the fields of the <see href="https://xrpl.org/transaction-formats.html">Transaction object</see> as well as the following additional fields:
/// </summary>
public class TransactionResponse
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

    /// <summary>
    /// (Optional) Set of bit-flags for this transaction.
    /// </summary>
    [JsonPropertyName("Flags")]
    public uint? Flags { get; set; }

    [JsonPropertyName("NetworkID")]
    public uint? NetworkId { get; set; }

    /// <summary>
    /// (Automatically added when signing) Hex representation of the public key that corresponds to the private key used to sign this transaction.
    /// If an empty string, indicates a multi-signature is present in the Signers field instead.
    /// </summary>
    [JsonPropertyName("SigningPubKey")]
    public string? SigningPublicKey { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// The SHA-512 hash of the transaction
    /// </summary>
    [JsonPropertyName("hash")]
    public string Hash { get; set; } = default!;

    /// <summary>
    /// The ledger index of the ledger that includes this transaction.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public uint LedgerIndex { get; set; }

    /// <summary>
    /// <see cref="TransactionMetadata">Transaction metadata</see>, which describes the results of the transaction.
    /// </summary>
    [JsonPropertyName("meta")]
    public TransactionMetadata Metadata { get; set; } = default!;

    /// <summary>
    /// If true, this data comes from a validated ledger version; if omitted or set to false, this data is not final.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
}
