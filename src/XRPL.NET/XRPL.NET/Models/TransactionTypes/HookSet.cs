using System.Text.Json.Serialization;

namespace XRPL.NET.Models.TransactionTypes;

public class HookSet
{
    [JsonPropertyName("Hook")]
    public Hook Hook { get; set; } = default!;
}
