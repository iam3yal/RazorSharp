namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridCellActionContext<TItem>
    where TItem : class
{
    public GridCellActionContext(GridColumn<TItem> column,
                                 TItem item,
                                 IReadOnlyCollection<GridActionButton<TItem>> actions)
    {
        Precondition.IsNotNull(column);
        Precondition.IsNotNull(item);
        Precondition.IsNotNull(actions);

        Column = column;
        Item = item;
        Actions = actions;
    }

    public GridColumn<TItem> Column { get; }

    public TItem Item { get; }

    internal IReadOnlyCollection<GridActionButton<TItem>> Actions { get; }
}