namespace RazorSharp.Components.Data;

[CascadingTypeParameter(nameof(TItem))]
public sealed class GridEditButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridEditButton()
        => (Name, EditState) = ("Edit", GridEditState.Read);

    [Parameter]
    public Func<TItem, ValueTask>? OnEdit { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        if (OnEdit is not null && context.Item is { } item)
        {
            await OnEdit(item);
        }
    }
}