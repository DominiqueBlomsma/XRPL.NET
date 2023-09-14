namespace XRPL.NET.Exceptions;

/// <summary>
/// The requested ledger object does not exist in the ledger.
/// </summary>
public class EntryNotFoundException : XrplException
{
    internal EntryNotFoundException(XrplException exception) : base(exception.ErrorCode, exception.Error, exception.ErrorMessage)
    {

    }
}
