namespace RazorSharp.Components;

using System.ComponentModel;

using Microsoft.AspNetCore.Components.Rendering;

using RazorSharp.Core.Components.Rendering;
using RazorSharp.Core.Contracts;
using RazorSharp.Dom;

public abstract class WebElementBase : WebComponent
{
    private readonly CssClassBuilder _classBuilder;

    protected WebElementBase(string tagName)
    {
        Precondition.IsNotEmpty(tagName);

        TagName = tagName;

        _classBuilder = new ();
    }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Id { get; set; }

    [Parameter]
    public ElementReference Ref { get; set; }

    [Parameter]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Action<ElementReference>? RefChanged { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? UserAttributes { get; set; }

    protected string? MergedClass { get; set; }

    protected string TagName { get; }

    protected virtual void BuildClass(CssClassBuilder builder)
    {
    }

    protected virtual void BuildElementRenderTree(RenderTreeBuilder builder)
    {
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        builder.OpenElement(0, TagName);

        builder.AddMultipleAttributes(1, UserAttributes);

        builder.AddAttributeIfNotNullOrEmpty(2, "id", Id);

        builder.AddAttributeIfNotNullOrEmpty(3, "class", GetFinalClassValue());

        BuildElementRenderTree(builder);

        builder.AddElementReferenceCapture(2147483647, capturedRef => {
            Ref = capturedRef;
            RefChanged?.Invoke(Ref);
        });

        builder.CloseElement();
    }

    protected override void OnDispose()
        => _classBuilder.Clear();

    [SuppressMessage("ReSharper", "ConvertIfStatementToSwitchStatement")]
    private string? GetFinalClassValue()
    {
        string? fullClass = null;

        BuildClass(_classBuilder);

        if (!string.IsNullOrEmpty(Class))
        {
            fullClass = Class;
        }

        if (!_classBuilder.IsEmpty && fullClass is not null)
        {
            fullClass = $"{Class} {_classBuilder}";
        }
        else if (!_classBuilder.IsEmpty)
        {
            fullClass = _classBuilder.ToString();
        }

        MergedClass = fullClass;

        return fullClass;
    }
}