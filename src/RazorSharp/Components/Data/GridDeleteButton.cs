namespace RazorSharp.Components.Data;

public sealed class GridDeleteButton<TItem> : GridActionButton<TItem>
    where TItem : class
{
    public GridDeleteButton()
        => (Name, EditState) = ("Delete", GridEditState.Read);

    [Parameter]
    public Func<ValueTask>? OnDelete { get; set; }

    protected override async ValueTask OnClickHandlerAsync(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        if (CascadingContext.Grid is { DataSource: { } source } && context.Item is { } item)
        {
            try
            {
                if (source.Remove(item))
                {
                    await row.ChangeEditStateAsync(GridEditState.None);

                    if (OnDelete is not null)
                    {
                        await OnDelete();
                    }
                }
            }
            catch (NotSupportedException ex)
            {
                throw new InvalidOperationException(
                    $"The '{nameof(CascadingContext.Grid.DataSource)}' does not support deletion.", ex);
            }
        }
    }
}