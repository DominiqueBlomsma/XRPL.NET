using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;

namespace XRPL.NET.Models.LedgerObjectTypes;

[LedgerEntryType("HookState")]
public class HookState : LedgerObjectBase
{
    [JsonPropertyName("HookStateData")]
    public string HookStateData { get; set; } = default!;

    [JsonPropertyName("HookStateKey")]
    public string HookStateKey { get; set; } = default!;

    [JsonPropertyName("OwnerNode")]
    public ulong OwnerNode { get; set; }

    /// <summary>
    /// A bit-map of boolean flags enabled for this hook state.
    /// </summary>
    [JsonPropertyName("Flags")]
    public HookStateFlags Flags { get; set; }
}
