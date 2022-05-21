namespace RazorSharp.Dom.Input.Formats;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public static partial class ISOWeekConverter
{
    private static readonly Regex WeekFormat = WeekFormatRegex();

    [SuppressMessage("ReSharper", "HeapView.ObjectAllocation")]
    public static string ToWeekFormat(DateTime dt)
    {
        var year = ISOWeek.GetYear(dt);
        var week = ISOWeek.GetWeekOfYear(dt);

        // REF: https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/week
        return $"{year}-W{week}";
    }

    public static string ToWeekFormat(DateOnly date)
        => ToWeekFormat(date.ToDateTime(TimeOnly.MinValue));

    public static bool TryParseWeek(string? value, out DateTime result)
    {
        result = default;

        if (value is not null)
        {
            var match = WeekFormat.Match(value);

            if (match.Success
                && int.TryParse(match.Groups["YEAR"].ValueSpan, out var year)
                && int.TryParse(match.Groups["WEEK"].ValueSpan, out var week))
            {
                // NOTE: This ensures that the first day of the week is the same for everyone, regardless of their cultural or regional preferences.
                result = ISOWeek.ToDateTime(year, week, DayOfWeek.Monday);

                return true;
            }
        }

        return false;
    }

    public static bool TryParseWeek(string? value, out DateOnly result)
    {
        result = default;

        if (TryParseWeek(value, out DateTime dt))
        {
            result = DateOnly.FromDateTime(dt);

            return true;
        }

        return false;
    }

    [GeneratedRegex(@"(?<YEAR>\d+)-W(?<WEEK>\d+)")]
    private static partial Regex WeekFormatRegex();
}