using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// The tx method retrieves information on a single <see href="https://xrpl.org/transaction-formats.html">transaction</see>, by its <see href="https://xrpl.org/transaction-basics.html#identifying-transactions">identifying hash</see>.
/// </summary>
public class TransactionRequest
{
    public TransactionRequest(string hash)
    {
        Hash = hash;
    }

    /// <summary>
    /// The 256-bit hash of the transaction, as hex.
    /// </summary>
    [JsonPropertyName("transaction")]
    public string Hash { get; set; }

    /// <summary>
    /// (Optional) If true, return transaction data and metadata as binary <see href="https://xrpl.org/serialization.html">serialized</see> to hexadecimal strings. If false, return transaction data and metadata as JSON. The default is false.
    /// </summary>
    [JsonPropertyName("binary")]
    public bool? Binary { get; set; }

    /// <summary>
    /// (Optional) Use this with <see cref="MaxLedger"></see> to specify a range of up to 1000 <see href="https://xrpl.org/basic-data-types.html#ledger-index">ledger indexes</see>, starting with this ledger (inclusive).
    /// If the server <see href="https://xrpl.org/tx.html#not-found-response">cannot find the transaction</see>, it confirms whether it was able to search all the ledgers in this range.
    /// </summary>
    [JsonPropertyName("min_ledger")]
    public uint MinLedger { get; set; }

    /// <summary>
    /// (Optional) Use this with <see cref="MinLedger"></see> to specify a range of up to 1000 <see href="https://xrpl.org/basic-data-types.html#ledger-index">ledger indexes</see>, starting with this ledger (inclusive).
    /// If the server <see href="https://xrpl.org/tx.html#not-found-response">cannot find the transaction</see>, it confirms whether it was able to search all the ledgers in this range.
    /// </summary>
    [JsonPropertyName("max_ledger")]
    public uint MaxLedger { get; set; }
}