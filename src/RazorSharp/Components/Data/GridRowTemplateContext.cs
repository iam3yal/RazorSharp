namespace RazorSharp.Components.Data;

public readonly struct GridRowTemplateContext<TItem>
    where TItem : class
{
    public GridRowTemplateContext(TItem? item, IEnumerable<object?>? cells)
    {
        Item = item;
        Cells = cells ?? Array.Empty<object>();
    }

    public TItem? Item { get; }

    public IEnumerable<object?> Cells { get; }
}