namespace RazorSharp.Components.Data;

public sealed class GridDeleteButton<TItem>() : GridActionButton<TItem>("Delete", GridEditState.Read)
    where TItem : class
{
    [Parameter]
    public Func<TItem, ValueTask<bool>>? OnDelete { get; set; }

    protected override async ValueTask OnClickAsync(GridRow<TItem> row, GridCellActionContext<TItem> context)
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