namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridCellChangeManager<TItem>
    where TItem : class
{
    private readonly List<GridCellDataContext<TItem>> _cells = new ();
    private readonly HashSet<GridRow<TItem>> _rows = new ();

    public bool EditRowCell(GridRow<TItem>? row, GridCellDataContext<TItem>? context, object? changedValue)
    {
        Precondition.IsNotNull(row);
        Precondition.IsNotNull(context);

        if (context.Edit(changedValue))
        {
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

            return true;
        }

        return false;
    }

    public void RemoveRow(GridRow<TItem>? row)
    {
        Precondition.IsNotNull(row);

        if (_rows.TryGetValue(row, out var existingRow))
        {
            foreach (var context in IterateCells(existingRow))
            {
                _cells.Remove(context);

                context.CellChangeAssociatedRow = null;
            }

            _rows.Remove(row);
        }
    }

    public bool SaveRowChanges(GridRow<TItem>? row)
    {
        Precondition.IsNotNull(row);

        if (_rows.TryGetValue(row, out var existingRow))
        {
            foreach (var context in IterateCells(existingRow))
            {
                if (context.Save())
                {
                    _cells.Remove(context);

                    context.CellChangeAssociatedRow = null;
                }
                else
                {
                    return false;
                }
            }

            _rows.Remove(row);

            return true;
        }

        return false;
    }

    private IEnumerable<GridCellDataContext<TItem>> IterateCells(GridRow<TItem> row)
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