using System.Text;
using XRPL.NET.Helpers;
using XRPL.NET.Models.TransactionTypes;

namespace XRPL.NET.Extensions;

public static class TransactionTypeExtensions
{
    public static string? GetUrl(this URITokenMint? uriTokenMint)
    {
        if (string.IsNullOrWhiteSpace(uriTokenMint?.URI))
        {
            return null;
        }

        var bytes = XrplHelper.HexToByteArray(uriTokenMint.URI);
        return Encoding.ASCII.GetString(bytes);
    }
}
