namespace RazorSharp.Demo.Data.Converters;

using System.Globalization;

public static class DateTimeConverter
{
    public static readonly string Format = "yyyy-MM-dd HH:mm:ss";

    public static DateTime FromString(ReadOnlySpan<char> value)
        => DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture);

    public static string ToString(DateTime value)
        => value.ToString(Format, CultureInfo.InvariantCulture);
}