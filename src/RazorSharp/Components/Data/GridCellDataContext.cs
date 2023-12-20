namespace RazorSharp.Components.Data;

using System.Reflection;

using RazorSharp.Core.Contracts;
using RazorSharp.Framework.Components.Data;

public sealed class GridCellDataContext<TItem> : ICellDataContext<TItem>
    where TItem : class
{
    private readonly PropertyInfo _property;

    public GridCellDataContext(TItem item, PropertyInfo property)
    {
        Precondition.IsNotNull(item);
        Precondition.IsNotNull(property);

        Item = item;
        _property = property;

        OriginalValue = property.GetValue(item, null);
        CurrentValue = OriginalValue;
    }

    public object? CurrentValue { get; private set; }

    public TItem? Item { get; }

    public object? OriginalValue { get; private set; }

    bool ICellDataContext<TItem>.Edit(object? newValue)
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

    void ICellDataContext<TItem>.Save()
    {
        _property.SetValue(Item, CurrentValue);

        OriginalValue = CurrentValue;
    }
}