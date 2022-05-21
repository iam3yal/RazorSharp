namespace RazorSharp.Demo.UI.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Components;
using RazorSharp.Dom;

public partial class Container : WebElementBase
{
    public Container() : base(Tag.Div)
    {
    }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        base.BuildElementRenderTree(builder);

        builder.AddContent(200, ChildContent);
    }
}