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
            // REVISIT: We shouldn't really have this flag but currently GridActionButton.ClickAsync calls ChangeEditStateAsync so we need to do it, will change later.
            var removed = false;

            try
            {
                if (source.Remove(item))
                {
                    removed = true;

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
            finally
            {
                if (removed)
                {
                    await row.ChangeEditStateAsync(GridEditState.None);
                }
                else
                {
                    await row.ChangeEditStateAsync(GridEditState.Read);
                }
            }
        }
    }
}