namespace RazorSharp.Demo.Data.Converters;

using System.Globalization;

public static class DateOnlyConverter
{
    public static readonly string[] Formats;

    static DateOnlyConverter()
    {
        Formats = new[]
        {
            "MM/dd/yyyy",
            "yyyy-MM-dd"
        };
    }

    public static DateOnly FromString(string value)
        => DateOnly.ParseExact(value, Formats, CultureInfo.InvariantCulture);

    public static string ToString(DateOnly value)
        => value.ToString(Formats[0], CultureInfo.InvariantCulture);
}