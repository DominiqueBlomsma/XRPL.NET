using System.Text.Json.Serialization;

namespace XRPL.NET.Models.TransactionTypes;

public class HookParameterSet
{
    [JsonPropertyName("HookParameter")]
    public HookParameter HookParameter { get; set; } = default!;
}
