namespace RazorSharp.Components.Data;

public sealed class GridSaveButton<TItem>
    : GridActionButton<TItem>
    where TItem : class
{
    public GridSaveButton()
        => (Name, EditState) = ("Save", GridEditState.Write);

    [Parameter]
    public Func<ValueTask<bool>>? OnSave { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        if (OnSave is not null)
        {
            var isSaved = CascadingContext.Grid.CellChangeManager.Save(row);

            if (isSaved)
            {
                isSaved = await OnSave();

                if (isSaved)
                {
                    await row.ToggleEditStateAsync(EditState);
                }
            }
        }
    }
}