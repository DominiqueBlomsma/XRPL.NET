namespace XRPL.NET.Exceptions;

/// <summary>
/// If the marker field provided is not acceptable.
/// </summary>
public class AccountMarkerMalformedException : XrplException
{
    internal AccountMarkerMalformedException(string account, XrplException exception) : 
        base(exception.ErrorCode, exception.Error, exception.ErrorMessage, $"Account: {account}")
    {
        Account = account;
    }

    public string Account { get; set; }
}