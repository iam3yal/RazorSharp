namespace RazorSharp.Components.Data;

public sealed class GridCancelButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridCancelButton()
        => (Name, EditState) = ("Cancel", GridEditState.Write);

    [Parameter]
    public Func<ValueTask>? OnCancel { get; set; }

    protected override async ValueTask OnClickAsync(GridRow<TItem> row, GridCellActionContext<TItem> context)
    {
        await row.CancelEditAsync();

        if (OnCancel is not null)
        {
            await OnCancel();
        }
    }
}