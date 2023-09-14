namespace XRPL.NET.Exceptions;

/// <summary>
/// The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.
/// </summary>
public class LedgerNotFoundException : XrplException
{
    internal LedgerNotFoundException(XrplException exception) : base(exception.ErrorCode, exception.Error, exception.ErrorMessage)
    {

    }
}