namespace RazorSharp.Components.Forms;

using RazorSharp.Tests.Kit;

public static class TimePickerTests
{
    [Fact]
    public static void Should_render_input_with_matched_type()
    {
        using var ctx = new RazorSharpTestContext();

        var timePickerComp = ctx.RenderComponent<TimePicker>();

        var element = timePickerComp.Find("input");
        var value = element.GetAttribute("type");

        Assert.Equal("time", value);
    }

    [Fact]
    public static void Should_render_with_Time_format()
    {
        using var ctx = new RazorSharpTestContext();

        var timePickerComp = ctx.RenderComponent<TimePicker>(parameters => {
            parameters.Add(p => p.Value, new TimeOnly(9, 0, 0));
        });

        var element = timePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("09:00:00", value);
    }
}