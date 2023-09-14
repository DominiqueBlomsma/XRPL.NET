using XRPL.NET.Enums;

namespace XRPL.NET.Models.BasicDataTypes;

/// <summary>
/// Many API methods require you to specify an instance of the ledger, with the data retrieved being considered up-to-date as of that particular version of the shared ledger.
/// If you do not specify a ledger, the server decides which ledger to use to serve the request.
/// By default, the server chooses the current (in-progress) ledger. In Reporting Mode, the server uses the most recent validated ledger instead.
/// <see href="https://xrpl.org/basic-data-types.html#specifying-ledgers">Specifying Ledgers</see>
/// </summary>
public class Ledger : Dictionary<string, object>
{
    /// <summary>
    /// Specify a ledger by its Ledger Index in the ledger_index parameter. Each closed ledger has a ledger index that is 1 higher than the previous ledger. (The very first ledger had ledger index 1.)
    /// </summary>
    /// <param name="index"></param>
    public Ledger(uint index)
    {
        Add("ledger_index", index);
    }

    /// <summary>
    /// Specify a ledger by its Hash value in the ledger_hash parameter.
    /// </summary>
    /// <param name="hash"></param>
    public Ledger(string hash)
    {
        Add("ledger_hash", hash);
    }

    /// <summary>
    /// Specify a ledger by one of the following shortcuts, in the ledger_index parameter:
    /// </summary>
    /// <param name="type"></param>
    public Ledger(LedgerIndexType type)
    {
        Add("ledger_index", type);
    }

    public override string ToString()
    {
        return string.Join(", ", this.Select(x => $"{x.Key}: {x.Value}"));
    }
}
