namespace XRPL.NET.Exceptions;

/// <summary>
/// The address specified in the account field of the request does not correspond to an account in the ledger.
/// </summary>
public class AccountNotFoundException : XrplException
{
    internal AccountNotFoundException(XrplException exception) : base(exception.ErrorCode, exception.Error, exception.ErrorMessage)
    {

    }
}
