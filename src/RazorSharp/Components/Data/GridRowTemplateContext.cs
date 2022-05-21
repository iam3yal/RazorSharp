namespace RazorSharp.Components.Data;

public readonly struct GridRowTemplateContext<TItem>
    where TItem : class
{
    public GridRowTemplateContext(TItem? item, IReadOnlyCollection<GridCellContext<TItem>?>? cells)
    {
        Item = item;
        Cells = cells ?? Array.Empty<GridCellContext<TItem>>();
    }

    public TItem? Item { get; }

    public IReadOnlyCollection<GridCellContext<TItem>?> Cells { get; }
}