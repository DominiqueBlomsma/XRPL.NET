using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

public class EmitDetails
{
    /// <summary>
    /// This field is a heuristic for detecting forkbombs.
    /// Fees are based on burden and will increase exponentially when a chain reaction is started to prevent the network becoming overun by self-reinforcing emitted transactions.
    /// </summary>
    [JsonPropertyName("EmitBurden")]
    public string EmitBurden { get; set; } = default!;

    /// <summary>
    /// This field keeps track of a chain of emitted transactions that in turn cause other transactions to be emitted.
    /// </summary>
    [JsonPropertyName("EmitGeneration")]
    public long EmitGeneration { get; set; }

    [JsonPropertyName("EmitHookHash")]
    public string EmitHookHash { get; set; } = default!;

    /// <summary>
    /// Emitted Transactions would be identical with the same fields and therefore have identical transaction hashes if a nonce were not used.
    /// However every node on the network needs to agree on the nonce, so a special Hook API to produce a deterministic nonce is made available.
    /// </summary>
    [JsonPropertyName("EmitNonce")]
    public string EmitNonce { get; set; } = default!;

    /// <summary>
    /// The Hook Execution that emitted the transaction is connected to the Originating Transaction. Therefore this field is always required for the efficient tracing of behaviour.
    /// </summary>
    [JsonPropertyName("EmitParentTxnID")]
    public string EmitParentTxnID { get; set; } = default!;
}
