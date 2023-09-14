namespace XRPL.NET.Models.BasicDataTypes;

/// <summary>
/// Rippled seems to return an integer if the string representation of a result is unknown
/// https://github.com/Xahau/xahaud/issues/74
/// </summary>
public class TransactionResult
{
    private const string SuccessResult = "tesSUCCESS";

    public string? Result { get; set; }

    public int? ResultCode { get; set; }

    public bool IsSuccessful => Result is SuccessResult;
}
