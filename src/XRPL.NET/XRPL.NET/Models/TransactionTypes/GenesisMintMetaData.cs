using System.Text.Json.Serialization;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Models.TransactionTypes;

public class GenesisMintMetaData
{
    /// <summary>
    /// The address of the account that will receive the minted native token.
    /// </summary>
    [JsonPropertyName("Destination")]
    public string Destination { get; set; } = default!;

    /// <summary>
    /// The amount of native token to be minted and distributed to the destination account.
    /// </summary>
    [JsonPropertyName("Amount")]
    public Currency Amount { get; set; } = default!;

    /// <summary>
    /// (Optional) The governance flags associated with the destination account.
    /// </summary>
    [JsonPropertyName("GovernanceFlags")]
    public string? GovernanceFlags { get; set; }

    /// <summary>
    /// (Optional) The governance marks associated with the destination account.
    /// </summary>
    [JsonPropertyName("GovernanceMarks")]
    public string? GovernanceMarks { get; set; }
}
