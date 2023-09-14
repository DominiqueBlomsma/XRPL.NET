using System.Text.RegularExpressions;

namespace XRPL.NET.Helpers;

public static class XrplAccountHelper
{
    private static readonly Regex RgxXrplAccountAddress = new(@"^r[1-9A-HJ-NP-Za-km-z]{25,33}$");

    public static bool IsXrplAccountAddress(this string? input) => !string.IsNullOrWhiteSpace(input) && RgxXrplAccountAddress.IsMatch(input);
}
