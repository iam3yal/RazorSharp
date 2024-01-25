namespace RazorSharp.Framework.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class CellChangeManager<TItem>
    where TItem : class
{
    private readonly List<ICellDataContext<TItem>> _cells = [];
    private readonly HashSet<TItem?> _items = [];

    public int TrackedCells
        => _cells.Count;

    public int TrackedItems
        => _items.Count;

    public bool Edit(ICellDataContext<TItem>? context, object? newValue)
    {
        Precondition.IsNotNull(context);

        if (context.Edit(newValue))
        {
            _items.Add(context.Item);

            if (!_cells.Contains(context))
            {
                _cells.Add(context);
            }

            return true;
        }

        return false;
    }

    public void Remove(TItem? item)
    {
        Precondition.IsNotNull(item);

        if (_items.TryGetValue(item, out var existingItem))
        {
            foreach (var context in IterateCells(existingItem))
            {
                _cells.Remove(context);
            }

            _items.Remove(item);
        }
    }

    public bool SaveChanges(TItem? item)
    {
        Precondition.IsNotNull(item);

        if (_items.TryGetValue(item, out var existingItem))
        {
            foreach (var context in IterateCells(existingItem))
            {
                context.Save();

                _cells.Remove(context);
            }

            _items.Remove(item);

            return true;
        }

        return false;
    }

    private IEnumerable<ICellDataContext<TItem>> IterateCells(TItem? item)
    {
        for (var i = _cells.Count - 1; i >= 0; i--)
        {
            var context = _cells[i];

            if (context.Item == item)
            {
                yield return context;
            }
        }
    }
}