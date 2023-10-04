using System.Text.Json.Serialization;
using XRPL.NET.Enums;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// https://xrpl-hooks.readme.io/docs/execution-order
/// </summary>
public class HookExecution
{
    /// <summary>
    /// Hooks can end in three ways: accept, rollback and error.
    /// This is not the same as sfHookReturnCode!
    /// </summary>
    [JsonPropertyName("HookResult")]
    public HookExecutionResultType HookResult { get; set; }

    /// <summary>
    /// The SHA512H of the Hook at the time it was executed.
    /// </summary>
    [JsonPropertyName("HookHash")]
    public string HookHash { get; set; } = default!;

    /// <summary>
    /// The account the Hook ran on.
    /// </summary>
    [JsonPropertyName("HookAccount")]
    public string HookAccount { get; set; } = default!;

    /// <summary>
    /// The integer returned as the third parameter of accept or rollback.
    /// </summary>
    [JsonPropertyName("HookReturnCode")]
    public ulong HookReturnCode { get; set; }

    /// <summary>
    /// The string returned in the first two parameters of accept or rollback, if any.
    /// </summary>
    [JsonPropertyName("HookReturnString")]
    public string HookReturnString { get; set; } = default!;

    /// <summary>
    /// The total number of webassembly instructions that were executed when the Hook ran.
    /// </summary>
    [JsonPropertyName("HookInstructionCount")]
    public ulong HookInstructionCount { get; set; }

    /// <summary>
    /// The total number of <see href="https://xrpl-hooks.readme.io/docs/emitted-transactions">Emitted Transactions</see> produced by the Hook.
    /// </summary>
    [JsonPropertyName("HookEmitCount")]
    public ushort HookEmitCount { get; set; }

    /// <summary>
    /// The order in which the Hook was executed (as distinct from other Hook Executions on the same Originating Transaction.)
    /// </summary>
    [JsonPropertyName("HookExecutionIndex")]
    public ushort HookExecutionIndex { get; set; }

    /// <summary>
    /// The number of <see href="https://xrpl-hooks.readme.io/docs/state-management">Hook State</see> changes the Hook made during execution.
    /// </summary>
    [JsonPropertyName("HookStateChangeCount")]
    public ushort HookStateChangeCount { get; set; }
}
