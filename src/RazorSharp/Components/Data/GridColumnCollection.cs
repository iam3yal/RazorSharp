namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridColumnCollection<TItem>
    where TItem : class
{
    private readonly IList<GridColumn<TItem>> _columns = new List<GridColumn<TItem>>();

    private int _lastIndex = -1;

    public int Count
        => _columns.Count;

    public GridColumn<TItem> this[int index]
        => _columns[index];

    public int Add(GridColumn<TItem> column)
    {
        Precondition.IsNotNull(column);

        _columns.Add(column);

        return ++_lastIndex;
    }
}