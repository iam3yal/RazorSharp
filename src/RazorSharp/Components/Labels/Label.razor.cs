namespace RazorSharp.Components.Labels;

using RazorSharp.Dom;
using RazorSharp.Framework;

public sealed partial class Label() : WebElementBase(Tag.Label)
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public object? Target { get; set; }

    protected override void OnParametersSet()
    {
        if (Target is not null and (WebElementBase { Id: null } or not WebElementBase and not string))
        {
            throw new InvalidParameterException(
                nameof(Target),
                $"Please use a '{typeof(string)}' or a type derived from '{typeof(WebElementBase)}' with a valid '{nameof(Id)}'.");
        }
    }
}