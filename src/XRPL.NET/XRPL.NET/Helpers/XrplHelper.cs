using System.Numerics;

namespace XRPL.NET.Helpers;

public static class XrplHelper
{
    public static readonly string XRP = "XRP";

    /// <summary>
    /// 0017 XLS-17d: XFL Developer-friendly representation of XRPL balances
    /// https://github.com/XRPLF/XRPL-Standards/discussions/39
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the value of <param name="hex"></param> is an invalid XFL</exception>
    public static decimal XflHexToDecimal(string hex)
    {
        var xfl = HexToLong(hex);
        if (xfl < 0)
        {
            throw new InvalidOperationException($"Invalid XFL HEX value: {hex}");
        }

        return XflToDecimal(xfl);
    }

    /// <summary>
    /// 0017 XLS-17d: XFL Developer-friendly representation of XRPL balances
    /// https://github.com/XRPLF/XRPL-Standards/discussions/39
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the value of <param name="bytes"></param> is an invalid XFL</exception>
    public static decimal XflBytesToDecimal(byte[] bytes)
    {
        var hex = BitConverter.ToString(bytes).Replace("-", string.Empty);
        return XflHexToDecimal(hex);
    }

    public static byte[] DecimalToXflBytes(decimal value, int length)
    {
        var xfl = DecimalToXfl(value);
        var hexValue = xfl.ToString("X8");
        var byteArray = new byte[length];

        // Iterate through the hexadecimal string in 2-character chunks
        for (var i = 0; i < hexValue.Length; i += 2) 
        {
            // Convert each 2-character chunk to a byte and add it to the byte array
            byteArray[i / 2] = Convert.ToByte(hexValue.Substring(i, 2), 16);
        }
        
        return byteArray;
    }

    public static decimal XflToDecimal(long xfl)
    {
        var isNegative = xfl > 0 && ((xfl >> 62) & 1) == 0;
        var mantissa = xfl > 0 ? (xfl - ((xfl >> 54) << 54)) : 0;
        var exponent = xfl > 0 ? ((xfl >> 54) & 0xFF) - 97 : 0;

        var result = (decimal)(mantissa * Math.Pow(10, exponent));
        return isNegative ? -result : result;
    }

    public static long DecimalToXfl(decimal value)
    {
        var exponent = 0;
        var d = ("" + value).ToLower();
        var s = d.Split('e');

        if (s.Length == 2)
        {
            exponent = int.Parse(s[1]);
            d = s[0];
        }

        s = d.Split('.');

        if (s.Length == 2)
        {
            d = d.Replace(".", "");
            exponent -= s[1].Length;
        }
        else if (s.Length > 2)
        {
            d = "0";
        }

        return XflFromBigInt(exponent, BigInteger.Parse(d));
    }

    private static long XflFromBigInt(BigInteger exponent, BigInteger mantissa)
    {
        var minMantissa = BigInteger.Parse("1000000000000000");
        var maxMantissa = BigInteger.Parse("9999999999999999");
        var minExponent = -96;
        var maxExponent = 80;

        // canonical zero
        if (mantissa == 0)
        {
            return 0;
        }

        // normalize
        var isNegative = mantissa < 0;
        if (isNegative)
        {
            mantissa *= -1;
        }

        while (mantissa > maxMantissa)
        {
            mantissa /= 10;
            exponent++;
        }
        while (mantissa < minMantissa)
        {
            mantissa *= 10;
            exponent--;
        }

        // canonical zero on mantissa underflow
        if (mantissa == 0)
        {
            return 0;
        }

        // under and overflows
        if (exponent > maxExponent || exponent < minExponent)
        {
            return -1; // note this is an "invalid" XFL used to propagate errors
        }

        exponent += 97;

        var xfl = isNegative ? BigInteger.Zero : BigInteger.One;
        xfl <<= 8;
        xfl |= exponent;
        xfl <<= 54;
        xfl |= mantissa;

        return (long)xfl;
    }

    public static byte[] HexToByteArray(string hexString)
    {
        if (hexString.Length % 2 != 0)
        {
            throw new ArgumentException("Hexadecimal string must have an even number of characters.");
        }

        var byteArray = new byte[hexString.Length / 2];
        for (var i = 0; i < hexString.Length; i += 2)
        {
            var hexByte = hexString.Substring(i, 2);
            byteArray[i / 2] = Convert.ToByte(hexByte, 16);
        }

        return byteArray;
    }

    public static long HexToLong(string hex)
    {
        return Convert.ToInt64(hex, 16);
    }

    public static ulong HexToULong(string hex)
    {
        return Convert.ToUInt64(hex, 16);
    }
}
