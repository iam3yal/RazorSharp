namespace RazorSharp.Components.Forms;

using System.Globalization;

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using RazorSharp.Dom.Input;

public partial class TextBox() : WebInputBase<string>(CultureInfo.CurrentCulture), ITextInput
{
    [Parameter]
    public string? AutoComplete { get; set; }

    [Parameter]
    public object? DataList { get; set; }

    [Parameter]
    public string? DirectionName { get; set; }

    [Parameter]
    public int Height { get; set; }

    [Parameter]
    public bool IsReadOnly { get; set; }

    [Parameter]
    public int MaxLength { get; set; } = -1;

    [Parameter]
    public int MinLength { get; set; } = -1;

    [Parameter]
    public string? Pattern { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public int Width { get; set; }

    protected override void BuildElementRenderTree(RenderTreeBuilder builder)
    {
        Type = InputType.Text;

        base.BuildElementRenderTree(builder);

        builder.AddAttribute(200, "autocomplete", AutoComplete);
        builder.AddAttribute(201, "required", Required);
        builder.AddAttribute(202, "dirname", DirectionName);
        builder.AddAttribute(203, "readonly", IsReadOnly);
        builder.AddAttribute(204, "placeholder", Placeholder);
        builder.AddAttribute(205, "list", DataList);
        builder.AddAttribute(206, "pattern", Pattern);
        builder.AddAttribute(207, "minlength", MinLength);
        builder.AddAttribute(208, "maxlength", MinLength);
    }

    protected virtual Task OnClick(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnCopyAsync(ClipboardEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnCutAsync(ClipboardEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnDoubleClick(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnKeyDown(KeyboardEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnKeyUp(KeyboardEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseDown(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseEnter(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseLeave(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseMove(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseOut(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseOver(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseUp(MouseEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnMouseWheel(WheelEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnPasteAsync(ClipboardEventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnPreCopyAsync(EventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnPreCutAsync(EventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnPrePasteAsync(EventArgs arg)
        => throw new NotImplementedException();

    protected virtual Task OnSelectAsync(EventArgs arg)
        => throw new NotImplementedException();
}