namespace RazorSharp.Components.Data;

public sealed partial class GridCell<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public GridCellContext<TItem>? Context { get; set; }
}