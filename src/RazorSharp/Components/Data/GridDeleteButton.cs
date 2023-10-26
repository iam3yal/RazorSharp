namespace RazorSharp.Components.Data;

public sealed class GridDeleteButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridDeleteButton()
        => (Name, EditState) = ("Delete", GridEditState.Read);

    [Parameter]
    public Func<TItem, ValueTask<bool>>? OnDelete { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        if (OnDelete is not null && context.Item is { } item)
        {
            var isDeleted = await OnDelete(item);

            if (isDeleted)
            {
                await row.ChangeEditStateAsync(GridEditState.None);
            }
        }
    }
}