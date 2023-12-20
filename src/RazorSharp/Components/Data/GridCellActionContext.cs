namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridCellActionContext<TItem>
    where TItem : class
{
    public GridCellActionContext(TItem item,
                                 IReadOnlyCollection<GridActionButton<TItem>> actions)
    {
        Precondition.IsNotNull(item);
        Precondition.IsNotNull(actions);

        Item = item;
        Actions = actions;
    }

    public TItem Item { get; }

    internal IReadOnlyCollection<GridActionButton<TItem>> Actions { get; }
}