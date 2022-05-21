namespace RazorSharp.Components.Data;

[CascadingTypeParameter(nameof(TItem))]
public sealed class GridEditButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridEditButton()
        => (Name, EditState) = ("Edit", GridEditState.Read);

    [Parameter]
    public Func<TItem, ValueTask>? OnEdit { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row)
    {
        if (OnEdit is not null && CascadingContext.Cell is { Context: { Item: { } item } })
        {
            await OnEdit(item);
        }
    }
}