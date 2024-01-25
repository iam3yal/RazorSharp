namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridColumnActionCollection<TItem>
    where TItem : class
{
    private readonly IList<GridActionButton<TItem>> _actions = [];

    private IReadOnlyCollection<GridActionButton<TItem>>? _cachedActions;

    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
    public IReadOnlyCollection<GridActionButton<TItem>> Items
        => _cachedActions ??= _actions.AsReadOnly();

    public void Add(GridActionButton<TItem> action)
    {
        Precondition.IsNotNull(action);

        _actions.Add(action);
        _cachedActions = null;
    }
}