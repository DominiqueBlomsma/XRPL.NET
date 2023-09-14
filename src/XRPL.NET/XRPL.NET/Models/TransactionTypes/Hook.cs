using System.Text.Json.Serialization;
using XRPL.NET.Flags;

namespace XRPL.NET.Models.TransactionTypes;

public class Hook
{
    [JsonPropertyName("Flags")]
    public HookSetFlags? Flags { get; set; }

    [JsonPropertyName("HookHash")]
    public string? HookHash { get; set; }
    
    [JsonPropertyName("HookApiVersion")]
    public uint? HookApiVersion { get; set; }

    [JsonPropertyName("CreateCode")]
    public string? CreateCode { get; set; }

    [JsonPropertyName("HookNamespace")]
    public string? HookNamespace { get; set; }

    [JsonPropertyName("HookOn")]
    public string? HookOn { get; set; }

    [JsonPropertyName("HookParameters")]
    public List<HookParameterSet>? HookParameters { get; set; }
}
