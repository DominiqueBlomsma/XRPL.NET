using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// https://docs.xahau.network/technical/protocol-reference/transactions/transaction-types/claimreward
/// </summary>
[TransactionType("ClaimReward")]
public class ClaimReward : TransactionBase
{
    public ClaimReward()
    {
        TransactionType = nameof(ClaimReward);
    }

    [JsonPropertyName("Flags")]
    public ClaimRewardFlags Flags { get; set; }

    /// <summary>
    /// (Optional) The genesis account.
    /// </summary>
    [JsonPropertyName("Issuer")]
    public string? Issuer { get; set; }
}
