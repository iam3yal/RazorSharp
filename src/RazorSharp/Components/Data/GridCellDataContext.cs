namespace RazorSharp.Components.Data;

using System.Reflection;

using RazorSharp.Core.Contracts;

public sealed class GridCellDataContext<TItem>
    where TItem : class
{
    private readonly PropertyInfo? _property;

    public GridCellDataContext(GridColumn<TItem> column, TItem item, PropertyInfo property)
    {
        Precondition.IsNotNull(column);
        Precondition.IsNotNull(item);
        Precondition.IsNotNull(property);

        Column = column;
        Item = item;
        _property = property;

        OriginalValue = property.GetValue(item, null);
        CurrentValue = OriginalValue;
    }

    public GridColumn<TItem> Column { get; }

    public object? CurrentValue { get; private set; }

    public TItem? Item { get; }

    public object? OriginalValue { get; private set; }

    internal GridRow<TItem>? CellChangeAssociatedRow { get; set; }

    internal bool Edit(object? newValue)
    {
        switch (newValue)
        {
            case bool @bool:
            {
                CurrentValue = @bool;
                return true;
            }
            default:
            {
                var value = newValue as string ?? "";

                switch (OriginalValue)
                {
                    case string:
                    {
                        CurrentValue = value;
                        return true;
                    }
                    case int:
                    {
                        if (int.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    case float:
                    {
                        if (float.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    case double:
                    {
                        if (double.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    case char:
                    {
                        if (char.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    case byte:
                    {
                        if (byte.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    case long:
                    {
                        if (long.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    case short:
                    {
                        if (short.TryParse(value, out var result))
                        {
                            CurrentValue = result;
                            return true;
                        }

                        break;
                    }
                    default:
                    {
                        throw new InvalidOperationException("The type is not yet supported.");
                    }
                }

                break;
            }
        }

        return false;
    }

    internal bool Save()
    {
        if (_property is not null)
        {
            _property.SetValue(Item, CurrentValue);

            OriginalValue = CurrentValue;

            return true;
        }

        return false;
    }
}