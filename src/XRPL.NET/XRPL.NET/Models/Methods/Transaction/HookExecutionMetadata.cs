using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// https://xrpl-hooks.readme.io/docs/execution-order
/// </summary>
public class HookExecutionMetadata
{
    [JsonPropertyName("HookExecution")]
    public HookExecution HookExecution { get; set; } = default!;
}
