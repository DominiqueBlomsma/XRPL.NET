using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// https://docs.xahau.network/technical/protocol-reference/transactions/transaction-types/genesismint-emitted-txn#genesismint-object
/// </summary>
public class GenesisMintMetaData
{
    [JsonPropertyName("GenesisMint")]
    public GenesisMint GenesisMint { get; set; } = default!;
}
