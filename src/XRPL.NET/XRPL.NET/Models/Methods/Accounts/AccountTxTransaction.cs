using System.Text.Json.Serialization;
using XRPL.NET.Models.Methods.Transaction;

namespace XRPL.NET.Models.Methods.Accounts;

public class AccountTxTransaction
{
    /// <summary>
    /// <see cref="TransactionMetadata">Transaction metadata</see>, which describes the results of the transaction.
    /// </summary>
    [JsonPropertyName("meta")]
    public TransactionMetadata Metadata { get; set; } = default!;

    /// <summary>
    /// (JSON mode only) JSON object defining the transaction
    /// </summary>
    [JsonPropertyName("tx")]
    public AccountTxTransactionTx? Tx { get; set; }

    /// <summary>
    /// (Binary mode only) Unique hashed String representing the transaction.
    /// </summary>
    [JsonPropertyName("tx_blob")]
    public string? TxBlob { get; set; }

    /// <summary>
    /// Whether or not the transaction is included in a validated ledger.
    /// Any transaction not yet in a validated ledger is subject to change.
    /// </summary>
    [JsonPropertyName("validated")]
    public bool Validated { get; set; }
}
