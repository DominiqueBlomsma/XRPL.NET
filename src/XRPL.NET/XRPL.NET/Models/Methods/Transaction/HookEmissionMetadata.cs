using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

public class HookEmissionMetadata
{
    [JsonPropertyName("HookEmission")]
    public HookEmission HookEmission { get; set; } = default!;
}
