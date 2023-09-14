using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

public class StateAccountingDetails
{
    /// <summary>
    /// The number of microseconds the server has spent in this state. (This is updated whenever the server transitions into another state.)
    /// </summary>
    [JsonPropertyName("duration_us")]
    public string DurationUs { get; set; } = default!;

    /// <summary>
    /// The number of times the server has changed into this state.
    /// </summary>
    [JsonPropertyName("transitions")]
    public string Transitions { get; set; } = default!;
}