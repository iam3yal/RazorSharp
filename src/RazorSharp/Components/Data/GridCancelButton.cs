namespace RazorSharp.Components.Data;

public sealed class GridCancelButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridCancelButton()
        => (Name, EditState) = ("Cancel", GridEditState.Write);

    [Parameter]
    public Func<ValueTask>? OnCancel { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        await CascadingContext.Grid.CellChangeManager.CancelAsync(row);

        if (OnCancel is not null)
        {
            await OnCancel();
        }
    }
}