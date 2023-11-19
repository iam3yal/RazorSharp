namespace RazorSharp.Components;

using RazorSharp.Dom;
using RazorSharp.Tests.TestDoubles.Testables;

public sealed class WebElementBaseTests : TestContext
{
    [Fact]
    public void Should_render_with_the_appended_value()
    {
        var webInput = RenderComponent<TestableWebElement>(parameters => {
            parameters.Add(p => p.Class, "foo");
            parameters.Add(p => p.ClassBuilder, new CssClassBuilder().Append("bar"));
        });

        var divElement = webInput.Find("div");
        var cssClass = divElement.GetAttribute("class");

        Assert.Equal("foo bar", cssClass);
    }

    [Fact]
    public void Should_render_with_the_value_assigned_to_Class()
    {
        var webInput = RenderComponent<TestableWebElement>(parameters => {
            parameters.Add(p => p.Class, "foo");
        });

        var divElement = webInput.Find("div");
        var cssClass = divElement.GetAttribute("class");

        Assert.Equal("foo", cssClass);
    }

    [Fact]
    public void Should_render_with_the_value_assigned_to_Id()
    {
        var webInput = RenderComponent<TestableWebElement>(parameters => {
            parameters.Add(p => p.Id, "foo");
        });

        var divElement = webInput.Find("div");
        var cssClass = divElement.GetAttribute("id");

        Assert.Equal("foo", cssClass);
    }
}