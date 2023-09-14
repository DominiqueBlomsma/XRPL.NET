using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// /The submit method applies a transaction and sends it to the network to be confirmed and included in future ledgers.
/// </summary>
public class SubmitRequest
{
    public SubmitRequest(string txBlob)
    {
        TxBlob = txBlob;
    }

    /// <summary>
    /// Hex representation of the signed transaction to submit. This can be a <see href="https://xrpl.org/multi-signing.html">multi-signed transaction</see>.
    /// </summary>
    [JsonPropertyName("tx_blob")]
    public string TxBlob { get; set; }

    /// <summary>
    /// If true, and the transaction fails locally, do not retry or relay the transaction to other servers.<br/>
    /// The default is false.
    /// </summary>
    [JsonPropertyName("fail_hard")]
    public bool? FailHard { get; set; }
}
