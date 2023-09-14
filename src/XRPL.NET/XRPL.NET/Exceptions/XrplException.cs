namespace XRPL.NET.Exceptions;

public class XrplException : Exception
{
    public XrplException(int? errorCode, string? error, string? errorMessage, string? customErrorMessage = null)
        : base($"ErrorCode: {errorCode}, Error: {error}, ErrorMessage: {errorMessage}{(!string.IsNullOrWhiteSpace(customErrorMessage) ? $", {customErrorMessage}" : string.Empty)}")
    {
        ErrorCode = errorCode;
        Error = error;
        ErrorMessage = errorMessage;
    }

    public int? ErrorCode { get; set; }
    public string? Error { get; set; }
    public string? ErrorMessage { get; set; }
}
