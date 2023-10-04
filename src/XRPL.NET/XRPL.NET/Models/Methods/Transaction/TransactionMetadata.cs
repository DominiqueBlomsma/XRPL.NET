using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Models.Methods.Transaction;

/// <summary>
/// Transaction metadata is a section of data that gets added to a transaction after it is processed.
/// Any transaction that gets included in a ledger has metadata, regardless of whether it is successful.
/// The transaction metadata describes the outcome of the transaction in detail.
/// </summary>
public class TransactionMetadata
{
    /// <summary>
    /// List of <see href="https://xrpl.org/ledger-object-types.html">ledger objects</see> that were created, deleted, or modified by this transaction, and specific changes to each.
    /// </summary>
    [JsonPropertyName("AffectedNodes")]
    public JsonArray AffectedNodes { get; set; } = default!; // TODO: Create strongly typed models

    /// <summary>
    /// When Hooks execute they leave behind information about the status of that execution.
    /// This appears in the Originating Transaction metadata as an sfHookExecutions block.
    /// </summary>
    [JsonPropertyName("HookExecutions")]
    public List<HookExecutionMetadata>? HookExecutions { get; set; }

    /// <summary>
    /// Integer	The transaction's position within the ledger that included it. This is zero-indexed. (For example, the value 2 means it was the 3rd transaction in that ledger.)
    /// </summary>
    [JsonPropertyName("TransactionIndex")]
    public uint TransactionIndex { get; set; }

    /// <summary>
    /// A <see href="https://xrpl.org/transaction-results.html">result code</see> indicating whether the transaction succeeded or how it failed.
    /// </summary>
    [JsonPropertyName("TransactionResult")]
    public TransactionResult TransactionResult { get; set; } = default!;

    /// <summary>
    /// (Omitted for non-Payment transactions) The <see href="https://xrpl.org/basic-data-types.html#specifying-currency-amounts">Currency Amount</see> actually received by the Destination account.
    /// Use this field to determine how much was delivered, regardless of whether the transaction is a <see href="https://xrpl.org/partial-payments.html">partial payment</see>.
    /// </summary>
    [JsonPropertyName("delivered_amount")]
    public Currency? DeliveredAmount { get; set; }
}
