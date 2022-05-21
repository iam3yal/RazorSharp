namespace RazorSharp.Demo.Data.Converters;

using System.Drawing;

public static class HtmlColorConverter
{
    public static Color FromString(string value)
        => ColorTranslator.FromHtml(value);

    public static string ToString(Color value)
        => ColorTranslator.ToHtml(value).ToLowerInvariant();
}