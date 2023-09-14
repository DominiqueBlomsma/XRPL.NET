using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

/// <summary>
/// Information about the last time the server closed a ledger, including the amount of time it took to reach a consensus and the number of trusted validators participating.
/// </summary>
public class LastClose
{
    /// <summary>
    /// The amount of time it took to reach a consensus on the most recently validated ledger version, in milliseconds.
    /// </summary>
    [JsonPropertyName("converge_time")]
    public int ConvergeTime { get; set; }

    /// <summary>
    /// How many trusted validators the server considered (including itself, if configured as a validator) in the consensus process for the most recently validated ledger version.
    /// </summary>
    [JsonPropertyName("proposers")]
    public int Proposers { get; set; }
}
