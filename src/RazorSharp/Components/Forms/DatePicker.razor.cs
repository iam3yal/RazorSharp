namespace RazorSharp.Components.Forms;

using System.Globalization;

using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Dom.Input;
using RazorSharp.Dom.Input.Formats;

public partial class DatePicker : WebInputBase<DateOnly>
{
    public DatePicker() : base(CultureInfo.InvariantCulture)
    {
    }

    [Parameter]
    public DateFormat Format { get; set; } = DateFormat.Date;

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        Type = Format switch
        {
            DateFormat.Date  => InputType.Date,
            DateFormat.Month => InputType.Month,
            DateFormat.Week  => InputType.Week,
            _                => InputType.Date
        };

        base.BuildElementRenderTree(builder);
    }

    protected override string FormatValue(DateOnly value)
        => DateTimeFormatter.FromDateOnly(value, Format);

    protected override Task OnParametersSetAsync()
    {
        if (!Enum.IsDefined(Format))
        {
            throw new InvalidOperationException($"The '{nameof(Format)}' parameter was assigned with an invalid value.");
        }

        return base.OnParametersSetAsync();
    }

    protected override bool TryParseValue(string? value,
                                          out DateOnly result,
                                          [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (Format is DateFormat.Week && ISOWeekConverter.TryParseWeek(value, out result))
        {
            validationErrorMessage = null;

            return true;
        }

        return base.TryParseValue(value, out result, out validationErrorMessage);
    }
}