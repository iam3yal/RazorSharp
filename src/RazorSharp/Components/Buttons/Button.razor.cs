namespace RazorSharp.Components.Buttons;

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using RazorSharp.Core.Components.Rendering;
using RazorSharp.Dom;

public sealed partial class Button() : WebElementBase(Tag.Button)
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        base.BuildElementRenderTree(builder);

        builder.AddEvent<MouseEventArgs>(200, "onclick", this, OnClickHandlerAsync);
        builder.AddContent(201, ChildContent);
    }

    private async Task OnClickHandlerAsync(MouseEventArgs e)
    {
        if (IsDisabled || !OnClick.HasDelegate)
        {
            return;
        }

        await OnClick.InvokeAsync(e);
    }
}