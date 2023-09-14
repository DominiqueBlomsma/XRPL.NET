namespace XRPL.NET.Exceptions;

/// <summary>
/// One or more fields are specified incorrectly, or one or more required fields are missing.
/// </summary>
public class InvalidParametersException : XrplException
{
    internal InvalidParametersException(XrplException exception) : base(exception.ErrorCode, exception.Error, exception.ErrorMessage)
    {

    }
}