namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridCellChangeManager<TItem>
    where TItem : class
{
    private readonly List<GridCellContext<TItem>> _cells = new ();
    private readonly HashSet<GridRow<TItem>> _rows = new ();

    public async ValueTask CancelAsync(GridRow<TItem> row)
    {
        Precondition.IsNotNull(row);

        if (_rows.TryGetValue(row, out var existingRow))
        {
            foreach (var context in IterateCells(existingRow))
            {
                context.CellChangeAssociatedRow = null;

                _cells.Remove(context);
            }

            _rows.Remove(row);

            await row.ChangeEditStateAsync(GridEditState.Read);
        }
    }

    public async ValueTask SaveAsync(GridRow<TItem> row)
    {
        Precondition.IsNotNull(row);

        if (_rows.TryGetValue(row, out var existingRow))
        {
            foreach (var context in IterateCells(existingRow))
            {
                context.SaveContent();

                context.CellChangeAssociatedRow = null;

                _cells.Remove(context);
            }

            _rows.Remove(row);

            await row.ChangeEditStateAsync(GridEditState.Read);
        }
    }

    internal void Track(GridRow<TItem> row, GridCellContext<TItem> context)
    {
        Precondition.IsNotNull(context);
        Precondition.IsNotNull(row);

        if (!_rows.TryGetValue(row, out var existingRow))
        {
            context.CellChangeAssociatedRow = row;

            _rows.Add(row);
        }
        else
        {
            context.CellChangeAssociatedRow = existingRow;
        }

        if (!_cells.Contains(context))
        {
            _cells.Add(context);
        }

        // TODO: We may need to do an update here when rows are moved or when there is discrepancy here. 
    }

    private IEnumerable<GridCellContext<TItem>> IterateCells(GridRow<TItem> row)
    {
        for (var i = _cells.Count - 1; i >= 0; i--)
        {
            var context = _cells[i];

            if (context.CellChangeAssociatedRow == row)
            {
                yield return context;
            }
        }
    }
}