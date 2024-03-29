namespace RazorSharp.Components.Data;

[CascadingTypeParameter(nameof(TItem))]
public sealed class GridEditButton<TItem>() : GridActionButton<TItem>("Edit", GridEditState.Read)
    where TItem : class
{
    [Parameter]
    public Func<TItem, ValueTask>? OnEdit { get; set; }

    protected override async ValueTask OnClickAsync(GridRow<TItem> row, GridCellActionContext<TItem> context)
    {
        await row.ToggleEditStateAsync(EditState);

        if (OnEdit is not null && context.Item is { } item)
        {
            await OnEdit(item);
        }
    }
}