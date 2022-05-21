namespace RazorSharp.Components.Labels;

using RazorSharp.Dom;

public sealed partial class Label : WebElementBase
{
    public Label() : base(Tag.Label)
    {
    }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public object? Target { get; set; }
}