namespace XRPL.NET.Exceptions;

public class XrplException : Exception
{
    public XrplException(int? errorCode, string? error, string? errorMessage)
        : base($"ErrorCode: {errorCode}, Error: {error}, ErrorMessage: {errorMessage}")
    {
        ErrorCode = errorCode;
        Error = error;
        ErrorMessage = errorMessage;
    }

    public int? ErrorCode { get; set; }
    public string? Error { get; set; }
    public string? ErrorMessage { get; set; }
}
