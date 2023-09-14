using System.Globalization;
using System.Text;

namespace XRPL.NET.Helpers;

public static class XrplCurrencyHelper
{
    public static decimal DropsPerXrp = 1000000m;

    public static string GetCurrencyCodeFromByteArray(byte[] byteArray)
    {
        if (byteArray.Length != 20)
        {
            throw new ArgumentException("Invalid byte array. Must be 20 bytes long.");
        }

        // Check if this is a non-standard currency code format
        if (byteArray[0] != 0x00 && byteArray[1] != 0x00 && byteArray[2] != 0x00 && byteArray[3] != 0x00 && byteArray[4] != 0x00 && byteArray[5] != 0x00 && byteArray[6] != 0x00 && byteArray[7] != 0x00)
        {
            return BitConverter.ToString(byteArray).Replace("-", string.Empty);
        }
        else
        {
            // This is a standard currency code format
            var currencyBytes = new byte[3];
            Buffer.BlockCopy(byteArray, 12, currencyBytes, 0, 3);

            return Encoding.ASCII.GetString(currencyBytes);
        }
    }

    public static byte[] GetCurrencyCodeByteArray(string currencyCode)
    {
        var byteArray = new byte[20];

        if (currencyCode.Length == 3)
        {
            // First 8 bits are 0x00
            byteArray[0] = 0x00;

            // Next 88 bits are all 0's
            for (var i = 1; i <= 11; i++)
            {
                byteArray[i] = 0x00;
            }

            // Next 24 bits represent 3 characters of ASCII
            var currencyBytes = Encoding.ASCII.GetBytes(currencyCode.ToUpperInvariant());
            Buffer.BlockCopy(currencyBytes, 0, byteArray, 12, currencyBytes.Length);

            // Next 40 bits are all 0's
            for (var i = 16; i <= 19; i++)
            {
                byteArray[i] = 0x00;
            }
        }
        else if (currencyCode.Length == 40)
        {
            var hexBytes = XrplHelper.HexToByteArray(currencyCode);
            if (hexBytes[0] == 0x00)
            {
                // First 8 bits must NOT be 0x00
                throw new ArgumentException("Invalid hexadecimal currency code.");
            }

            Buffer.BlockCopy(hexBytes, 0, byteArray, 0, hexBytes.Length);
        }
        else
        {
            // Non-standard currency code format
            var currencyBytes = Encoding.ASCII.GetBytes(currencyCode.ToUpperInvariant());
            Buffer.BlockCopy(currencyBytes, 0, byteArray, 0, Math.Min(currencyBytes.Length, 20));
        }

        return byteArray;
    }

    public static decimal DropsHexToDecimal(string hex)
    {
        var drops = XrplHelper.HexToLong(hex);
        return drops / DropsPerXrp;
    }

    public static decimal DropsLongToDecimal(ulong drops)
    {
        return drops / DropsPerXrp;
    }

    public static decimal StringValueToDecimal(string value)
    {
        if (!decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
        {
            throw new FormatException($"Unable to convert string number \"{value}\" to a decimal.");
        }

        return result;
    }

    public static ulong StringDropsToULong(string drops) => Convert.ToUInt64(drops);

    public static decimal StringDropsToDecimal(string drops)
    {
        var value = StringDropsToULong(drops);
        return DropsLongToDecimal(value);
    }

    public static decimal TruncateToXrpDecimal(decimal value)
    {
        return Math.Truncate(value * DropsPerXrp) / DropsPerXrp;
    }
}
