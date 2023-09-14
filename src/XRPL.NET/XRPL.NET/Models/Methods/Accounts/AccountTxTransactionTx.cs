using System.Text.Json.Serialization;
using XRPL.NET.Models.BasicDataTypes;
using XRPL.NET.Models.Methods.Transaction;
using XRPL.NET.Models.TransactionTypes;

namespace XRPL.NET.Models.Methods.Accounts;

public class AccountTxTransactionTx : TransactionBase
{
    [JsonPropertyName("Destination")]
    public string Destination { get; set; } = default!;

    [JsonPropertyName("Amount")]
    public Currency Amount { get; set; } = default!;

    [JsonPropertyName("EmitDetails")]
    public EmitDetails? EmitDetails { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; } = default!;

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#ledger-index">ledger index</see> of the ledger version that included this transaction.
    /// </summary>
    [JsonPropertyName("ledger_index")]
    public uint? LedgerIndex { get; set; }
}
