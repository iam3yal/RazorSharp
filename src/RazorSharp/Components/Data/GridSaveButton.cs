namespace RazorSharp.Components.Data;

public sealed class GridSaveButton<TItem>
    : GridActionButton<TItem>
    where TItem : class
{
    public GridSaveButton()
        => (Name, EditState) = ("Save", GridEditState.Write);

    [Parameter]
    public Func<ValueTask>? OnSave { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row)
    {
        await CascadingContext.Grid.CellChangeManager.SaveAsync(row);

        if (OnSave is not null)
        {
            await OnSave();
        }
    }
}