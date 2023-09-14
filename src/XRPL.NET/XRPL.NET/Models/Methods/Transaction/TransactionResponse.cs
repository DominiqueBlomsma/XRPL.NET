using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// The response follows the <see href="https://xrpl.org/response-formatting.html">standard format</see>, with a successful result containing the fields of the <see href="https://xrpl.org/transaction-formats.html">Transaction object</see> as well as the following additional fields:
/// </summary>
public class TransactionResponse
{
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
