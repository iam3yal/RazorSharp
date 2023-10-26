namespace RazorSharp.Components.Data;

public sealed class GridSaveButton<TItem>
    : GridActionButton<TItem>
    where TItem : class
{
    public GridSaveButton()
        => (Name, EditState) = ("Save", GridEditState.Write);

    [Parameter]
    public Func<bool, ValueTask<bool>>? OnSave { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        var isSaved = CascadingContext.Grid.CellChangeManager.Save(row);

        if (OnSave is not null)
        {
            isSaved = await OnSave(isSaved);
        }

        if (isSaved)
        {
            await row.ToggleEditStateAsync(EditState);
        }
    }
}