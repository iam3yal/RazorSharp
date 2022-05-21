namespace RazorSharp.Components.Data;

using System.Reflection;

public sealed class GridCellContext<TItem>
    where TItem : class
{
    private readonly PropertyInfo? _property;

    public GridCellContext(GridColumn<TItem> column, TItem? item, int index, object? data)
    {
        Column = column;
        Item = item;

        switch (data)
        {
            case PropertyInfo[] properties:
            {
                if (item is not null)
                {
                    var property = properties.ElementAtOrDefault(index);

                    if (property is not null)
                    {
                        _property = property;

                        OriginalContent = property.GetValue(item, null);

                        CurrentContent = OriginalContent;
                    }
                }

                break;
            }
            case IReadOnlyCollection<GridActionButton<TItem>> actions:
            {
                Actions = actions;
                break;
            }
        }
    }

    public IReadOnlyCollection<GridActionButton<TItem>>? Actions { get; }

    public GridColumn<TItem> Column { get; }

    public object? CurrentContent { get; set; }

    public TItem? Item { get; }

    public object? OriginalContent { get; private set; }

    internal GridRow<TItem>? CellChangeAssociatedRow { get; set; }

    public void SaveContent()
    {
        if (_property is not null)
        {
            _property.SetValue(Item, CurrentContent);

            OriginalContent = CurrentContent;
        }
    }
}