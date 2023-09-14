using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

public class SubmitResponse
{
    /// <summary>
    /// Text result code indicating the preliminary result of the transaction, for example `tesSUCCESS`.
    /// </summary>
    [JsonPropertyName("engine_result")]
    public string EngineResult { get; set; } = default!;

    /// <summary>
    /// Numeric version of the result code.
    /// </summary>
    [JsonPropertyName("engine_result_code")]
    public int EngineResultCode { get; set; } = default!;

    /// <summary>
    /// Human-readable explanation of the transaction's preliminary result.
    /// </summary>
    [JsonPropertyName("engine_result_message")]
    public string EngineResultMessage { get; set; } = default!;

    /// <summary>
    /// The complete transaction in hex string format.
    /// </summary>
    [JsonPropertyName("tx_blob")]
    public string TxBlob { get; set; } = default!;

    /// <summary>
    /// The complete transaction in JSON format.
    /// </summary>
    [JsonPropertyName("tx_json")]
    public SubmitTxJsonData? TxJson { get; set; } = default!;
}
