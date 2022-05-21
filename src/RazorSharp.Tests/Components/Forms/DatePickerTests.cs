namespace RazorSharp.Components.Forms;

using Microsoft.AspNetCore.Components;

using RazorSharp.Dom.Input.Formats;
using RazorSharp.Tests.Kit;

public static class DatePickerTests
{
    [Theory]
    [InlineData(DateFormat.Date, "date")]
    [InlineData(DateFormat.Month, "month")]
    [InlineData(DateFormat.Week, "week")]
    public static void Should_render_input_with_matched_type(DateFormat format, string type)
    {
        using var ctx = new RazorSharpTestContext();

        var datePickerComp = ctx.RenderComponent<DatePicker>(parameters => {
            parameters.Add(p => p.Format, format);
        });

        var element = datePickerComp.Find("input");
        var value = element.GetAttribute("type");

        Assert.Equal(type, value);
    }

    [Fact]
    public static void Should_render_with_Date_format()
    {
        using var ctx = new RazorSharpTestContext();

        var datePickerComp = ctx.RenderComponent<DatePicker>(parameters => {
            parameters.Add(p => p.Value, new DateOnly(2018, 07, 22));
            parameters.Add(p => p.Format, DateFormat.Date);
        });

        var element = datePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("2018-07-22", value);
    }

    [Fact]
    public static void Should_render_with_Month_format()
    {
        using var ctx = new RazorSharpTestContext();

        var datePickerComp = ctx.RenderComponent<DatePicker>(parameters => {
            parameters.Add(p => p.Value, new DateOnly(2018, 03, 01));
            parameters.Add(p => p.Format, DateFormat.Month);
        });

        var element = datePickerComp.Find("input");
        var value = element.GetAttribute("value");

        Assert.Equal("2018-03", value);
    }

    [Fact]
    public static async Task Should_render_with_Week_format()
    {
        using var ctx = new RazorSharpTestContext();

        var value = new DateOnly(2018, 06, 25);

        var datePickerComp = ctx.RenderComponent<DatePicker>(parameters => {
            parameters.Bind(p => p.Value, value, newValue => value = newValue, () => value);
            parameters.Add(p => p.Format, DateFormat.Week);
        });

        var element = datePickerComp.Find("input");
        await element.ChangeAsync(new ChangeEventArgs { Value = "2017-W26" });
        var changedValue = element.GetAttribute("value");

        Assert.Equal("2017-W26", changedValue);
    }

    [Fact]
    public static void Should_throw_when_invalid_Format_is_provided()
    {
        var ex = Record.Exception(() => {
            using var ctx = new RazorSharpTestContext();

            ctx.RenderComponent<DatePicker>(parameters => {
                parameters.Add(p => p.Value, new DateOnly(2018, 06, 12));
                parameters.Add(p => p.Format, (DateFormat) 0);
            });
        });

        Assert.Multiple(() => Assert.IsType<InvalidOperationException>(ex),
                        () => Assert.StartsWith(
                            $"The '{nameof(DatePicker.Format)}' parameter was assigned with an invalid value.",
                            ex?.Message));
    }
}