namespace RazorSharp.Components;

using RazorSharp.Dom;
using RazorSharp.Tests.Kit;
using RazorSharp.Tests.TestDoubles.Testables;

public static class WebElementBaseTests
{
    [Fact]
    public static void Should_render_with_the_appended_value()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebElement>(parameters => {
            parameters.Add(p => p.Class, "foo");
            parameters.Add(p => p.ClassBuilder, new CssClassBuilder().Append("bar"));
        });

        var element = webInputComp.Find("div");
        var cssClass = element.GetAttribute("class");

        Assert.Equal("foo bar", cssClass);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Class()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebElement>(parameters => {
            parameters.Add(p => p.Class, "foo");
        });

        var element = webInputComp.Find("div");
        var cssClass = element.GetAttribute("class");

        Assert.Equal("foo", cssClass);
    }

    [Fact]
    public static void Should_render_with_the_value_assigned_to_Id()
    {
        using var ctx = new RazorSharpTestContext();

        var webInputComp = ctx.RenderComponent<TestableWebElement>(parameters => {
            parameters.Add(p => p.Id, "foo");
        });

        var element = webInputComp.Find("div");
        var cssClass = element.GetAttribute("id");

        Assert.Equal("foo", cssClass);
    }
}