using System.Text.Json.Serialization;
using XRPL.NET.Attributes;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// https://xrpl-hooks.readme.io/docs/sethook-transaction
/// </summary>
[TransactionType("SetHook")]
public class SetHook : TransactionBase
{
    public SetHook()
    {
        TransactionType = nameof(SetHook);
    }

    [JsonPropertyName("Flags")]
    public uint Flags { get; set; } // TODO: Implement custom flags

    [JsonPropertyName("Hooks")]
    public List<HookSet> Hooks { get; set; } = default!;
}
