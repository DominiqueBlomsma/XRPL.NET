using System.Text.Json.Serialization;
using XRPL.NET.Attributes;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// https://docs.xahau.network/technical/protocol-reference/transactions/transaction-types/genesismint-emitted-txn#genesismint-object
/// </summary>
[TransactionType("GenesisMint")]
public class GenesisMint : TransactionBase
{
    public GenesisMint()
    {
        TransactionType = nameof(GenesisMint);
    }

    [JsonPropertyName("GenesisMints")]
    public List<GenesisMintObject>? GenesisMints { get; set; }
}
