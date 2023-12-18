using System.Text.Json.Serialization;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// https://docs.xahau.network/technical/protocol-reference/transactions/transaction-types/genesismint-emitted-txn#genesismint-object
/// </summary>
public class GenesisMintObject
{
    [JsonPropertyName("GenesisMint")]
    public GenesisMintMetaData GenesisMint { get; set; } = default!;
}
