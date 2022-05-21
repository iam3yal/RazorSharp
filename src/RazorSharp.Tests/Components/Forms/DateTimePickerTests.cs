namespace RazorSharp.Components.Forms;

using Microsoft.AspNetCore.Components;

using RazorSharp.Dom.Input.Formats;
using RazorSharp.Tests.Kit;

public static class DateTimePickerTests
{
    [Theory]
    [InlineData(DateTimeFormat.DateTime, "datetime-local")]
    [InlineData(DateTimeFormat.Date, "date")]
    [InlineData(DateTimeFormat.Month, "month")]
    [InlineData(DateTimeFormat.Week, "week")]
    [InlineData(DateTimeFormat.Time, "time")]
    public static void Should_render_input_with_matched_type(DateTimeFormat format, string type)
    {
        using var ctx = new RazorSharpTestContext();

        var datetimePickerComp = ctx.RenderComponent<DateTimePicker>(parameters => {
            parameters.Add(p => p.Format, format);
        });

        var element = datetimePickerComp.Find("input");
        var value = element.GetAttribute("type");

        Assert.Equal(type, value);
    }

    [Fact]
    public static void Should_render_with_Date_format()
    {
        using var ctx = new RazorSharpTestContext();

        var datetimePickerComp = ctx.RenderComponent<DateTimePicker>(parameters => {
            parameters.Add(p => p.Value, new DateTime(2018, 07, 22));
            parameters.Add(p => p.Format, DateTimeFormat.Date);
        });

        var element = datetimePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("2018-07-22", value);
    }

    [Fact]
    public static void Should_render_with_DateTime_format()
    {
        using var ctx = new RazorSharpTestContext();

        var datetimePickerComp = ctx.RenderComponent<DateTimePicker>(parameters => {
            parameters.Add(p => p.Value, new DateTime(2018, 06, 12, 19, 30, 0));
            parameters.Add(p => p.Format, DateTimeFormat.DateTime);
        });

        var element = datetimePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("2018-06-12T19:30:00", value);
    }

    [Fact]
    public static void Should_render_with_Month_format()
    {
        using var ctx = new RazorSharpTestContext();

        var datetimePickerComp = ctx.RenderComponent<DateTimePicker>(parameters => {
            parameters.Add(p => p.Value, new DateTime(2018, 03, 01));
            parameters.Add(p => p.Format, DateTimeFormat.Month);
        });

        var element = datetimePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("2018-03", value);
    }

    [Fact]
    public static void Should_render_with_Time_format()
    {
        using var ctx = new RazorSharpTestContext();

        var datetimePickerComp = ctx.RenderComponent<DateTimePicker>(parameters => {
            parameters.Add(p => p.Value, new DateTime(1, 1, 1, 9, 0, 0));
            parameters.Add(p => p.Format, DateTimeFormat.Time);
        });

        var element = datetimePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("09:00:00", value);
    }

    [Fact]
    public static async Task Should_render_with_Week_format()
    {
        using var ctx = new RazorSharpTestContext();

        var value = new DateTime(2018, 06, 25);

        var datetimePickerComp = ctx.RenderComponent<DateTimePicker>(parameters => {
            parameters.Bind(p => p.Value, value, newValue => value = newValue, () => value);
            parameters.Add(p => p.Format, DateTimeFormat.Week);
        });

        var element = datetimePickerComp.Find("input");
        await element.ChangeAsync(new ChangeEventArgs { Value = "2017-W26" });
        var changedValue = element.GetAttribute("value");

        Assert.Equal("2017-W26", changedValue);
    }

    [Fact]
    public static void Should_throw_when_invalid_Format_is_provided()
    {
        var ex = Record.Exception(() => {
            using var ctx = new RazorSharpTestContext();

            ctx.RenderComponent<DateTimePicker>(parameters => {
                parameters.Add(p => p.Value, new DateTime(2018, 06, 12, 19, 30, 0));
                parameters.Add(p => p.Format, (DateTimeFormat) 0);
            });
        });

        Assert.Multiple(() => Assert.IsType<InvalidOperationException>(ex),
                        () => Assert.StartsWith(
                            $"The '{nameof(DateTimePicker.Format)}' parameter was assigned with an invalid value.",
                            ex?.Message));
    }
}