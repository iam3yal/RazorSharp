namespace RazorSharp.Framework.Components.Data;

public interface ICellDataContext<out TItem>
    where TItem : class
{
    TItem? Item { get; }

    bool Edit(object? newValue);

    void Save();
}