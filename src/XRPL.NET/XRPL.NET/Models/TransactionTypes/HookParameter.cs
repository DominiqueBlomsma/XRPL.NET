using System.Text.Json.Serialization;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// https://xrpl-hooks.readme.io/docs/parameters
/// </summary>
public class HookParameter
{
    [JsonPropertyName("HookParameterName")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("HookParameterValue")]
    public string Value { get; set; } = default!;
}
