namespace RazorSharp.Components.Forms;

using System.Globalization;

using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Dom.Input;
using RazorSharp.Dom.Input.Formats;

[SuppressMessage("ReSharper", "StaticMemberInGenericType")]
public partial class DateTimePicker() : WebInputBase<DateTime>(CultureInfo.InvariantCulture)
{
    [Parameter]
    public DateTimeFormat Format { get; set; } = DateTimeFormat.DateTime;

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        Type = Format switch
        {
            DateTimeFormat.DateTime => InputType.DateTime,
            DateTimeFormat.Date     => InputType.Date,
            DateTimeFormat.Month    => InputType.Month,
            DateTimeFormat.Week     => InputType.Week,
            DateTimeFormat.Time     => InputType.Time,
            _                       => InputType.DateTime
        };

        base.BuildElementRenderTree(builder);
    }

    protected override string FormatValue(DateTime value)
        => DateTimeFormatter.FromDateTime(value, Format);

    protected override Task OnParametersSetAsync()
    {
        if (!Enum.IsDefined(Format))
        {
            throw new InvalidOperationException(
                $"The '{nameof(Format)}' parameter was assigned with an invalid value.");
        }

        return base.OnParametersSetAsync();
    }

    protected override bool TryParseValue(string? value,
                                          out DateTime result,
                                          [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (Format is DateTimeFormat.Week && ISOWeekConverter.TryParseWeek(value, out result))
        {
            validationErrorMessage = null;

            return true;
        }

        return base.TryParseValue(value, out result, out validationErrorMessage);
    }
}