namespace RazorSharp.Components.Data;

public sealed class GridCancelButton<TItem>() : GridActionButton<TItem>("Cancel", GridEditState.Write)
    where TItem : class
{
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