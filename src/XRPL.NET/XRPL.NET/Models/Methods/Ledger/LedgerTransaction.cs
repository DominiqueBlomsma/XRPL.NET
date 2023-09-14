using System.Text.Json.Serialization;
using XRPL.NET.Converters;
using XRPL.NET.Models.TransactionTypes;

namespace XRPL.NET.Models.Methods.Ledger;

[JsonConverter(typeof(LedgerTransactionConverter))]
public class LedgerTransaction
{
    /// <summary>
    /// The SHA-512 hash of the transaction
    /// </summary>
    public string? Hash { get; set; }

    public TransactionBase? Transaction { get; set; }
}
