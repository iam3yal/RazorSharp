namespace RazorSharp.Tests.TestDoubles.Testables;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Components;
using RazorSharp.Dom;

public sealed class TestableWebElement : WebElementBase
{
    public TestableWebElement() : base(Tag.Div)
    {
    }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public CssClassBuilder? ClassBuilder { get; set; }

    protected override void BuildClass(CssClassBuilder builder)
        => builder.Append(ClassBuilder);

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        base.BuildElementRenderTree(builder);

        builder.AddContent(200, ChildContent);
    }
}