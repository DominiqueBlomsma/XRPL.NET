using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

public class HookEmission
{
    /// <summary>
    /// The SHA512H of the Hook at the time it was executed.
    /// </summary>
    [JsonPropertyName("HookHash")]
    public string HookHash { get; set; } = default!;

    /// <summary>
    /// The account the Hook ran on.
    /// </summary>
    [JsonPropertyName("HookAccount")]
    public string HookAccount { get; set; } = default!;

    /// <summary>
    /// The identifying hash of the emitted transaction.
    /// </summary>
    [JsonPropertyName("EmittedTxnID")]
    public string EmittedTxnID { get; set; } = default!;

    /// <summary>
    /// Emitted Transactions would be identical with the same fields and therefore have identical transaction hashes if a nonce were not used.
    /// </summary>
    [JsonPropertyName("EmitNonce")]
    public string? EmitNonce { get; set; }
}
