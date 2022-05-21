namespace RazorSharp.Dom.Input.Formats;

using System.ComponentModel;
using System.Globalization;

public static class DateTimeFormatter
{
    // REF: https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/date
    private const string DateInputFormat = "yyyy-MM-dd";

    // REF: https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/datetime-local
    private const string DateTimeInputFormat = "yyyy-MM-ddTHH:mm:ss";

    // REF: https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/month
    private const string MonthInputFormat = "yyyy-MM";

    // REF: https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/time
    private const string TimeInputFormat = "HH:mm:ss";

    public static string FromDateOnly(DateOnly date, DateFormat format)
    {
        return format switch
        {
            DateFormat.Date => date.ToString(DateInputFormat, CultureInfo.InvariantCulture),
            DateFormat.Month => date.ToString(MonthInputFormat, CultureInfo.InvariantCulture),
            DateFormat.Week => ISOWeekConverter.ToWeekFormat(date),
            _ => throw new InvalidEnumArgumentException($"The provided '{nameof(DateFormat)}' value is invalid.")
        };
    }

    public static string FromDateTime(DateTime dt, DateTimeFormat format)
    {
        return format switch
        {
            DateTimeFormat.DateTime => dt.ToString(DateTimeInputFormat, CultureInfo.InvariantCulture),
            DateTimeFormat.Date => FromDateTime(dt, DateFormat.Date),
            DateTimeFormat.Month => FromDateTime(dt, DateFormat.Month),
            DateTimeFormat.Week => FromDateTime(dt, DateFormat.Week),
            DateTimeFormat.Time => FromDateTime(dt),
            _ => throw new InvalidEnumArgumentException($"The provided '{nameof(DateTimeFormat)}' value is invalid.")
        };
    }

    public static string FromTimeOnly(TimeOnly time)
        => time.ToString(TimeInputFormat, CultureInfo.InvariantCulture);

    private static string FromDateTime(DateTime dt, DateFormat format)
        => FromDateOnly(DateOnly.FromDateTime(dt), format);

    private static string FromDateTime(DateTime dt)
        => FromTimeOnly(TimeOnly.FromDateTime(dt));
}