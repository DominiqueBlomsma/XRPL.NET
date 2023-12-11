using System.Text.Json.Serialization;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Models.Methods.Transaction;

public class GenesisMint
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

}
