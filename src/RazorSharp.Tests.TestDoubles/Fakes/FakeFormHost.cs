namespace RazorSharp.Tests.TestDoubles.Fakes;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Components;

public sealed class FakeFormHost : WebComponent
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EditContext? EditContext { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenComponent<CascadingValue<EditContext>>(0);
        builder.AddAttribute(1, "Value", EditContext);
        builder.AddAttribute(2, "ChildContent", ChildContent);
        builder.CloseComponent();
    }
}