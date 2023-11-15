namespace RazorSharp.Components.Data;

public sealed class GridSaveButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridSaveButton() : base("Save", GridEditState.Write)
    {
    }

    [Parameter]
    public Func<GridSaveButtonEventArgs, ValueTask>? OnSave { get; set; }

    protected override async ValueTask OnClickAsync(GridRow<TItem> row, GridCellActionContext<TItem> context)
    {
        var isSaved = row.Save();

        GridSaveButtonEventArgs? args = null;

        if (OnSave is not null)
        {
            args = new GridSaveButtonEventArgs(isSaved);

            await OnSave(args);
        }

        if (isSaved)
        {
            await row.ToggleEditStateAsync(EditState);

            if (args is not null)
            {
                args.RowEditState = row.EditState;
            }
        }
    }
}