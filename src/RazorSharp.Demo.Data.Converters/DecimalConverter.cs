namespace RazorSharp.Demo.Data.Converters;

using System.Globalization;

public static class DecimalConverter
{
    public static decimal FromString(string value)
        => decimal.Parse(value, NumberStyles.Currency);

    public static string ToString(decimal value)
        => value.ToString("C");
}