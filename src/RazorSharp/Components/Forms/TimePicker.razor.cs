namespace RazorSharp.Components.Forms;

using System.Globalization;

using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Dom.Input;
using RazorSharp.Dom.Input.Formats;

public partial class TimePicker : WebInputBase<TimeOnly>
{
    public TimePicker() : base(CultureInfo.InvariantCulture)
    {
    }

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        Type = InputType.Time;

        base.BuildElementRenderTree(builder);
    }

    protected override string FormatValue(TimeOnly value)
        => DateTimeFormatter.FromTimeOnly(value);
}