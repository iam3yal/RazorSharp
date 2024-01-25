namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public sealed class GridComponentRegistry
{
    private readonly Dictionary<Type, IComponent> _registry = new ();

    public void Add<TKey>(IComponent component)
        where TKey : class
    {
        Precondition.IsNotNull(component);

        _registry.Add(typeof(TKey), component);
    }

    public bool TryGetComponent<TKey>([NotNullWhen(true)] out TKey? component)
        where TKey : class
    {
        if (_registry.TryGetValue(typeof(TKey), out var c))
        {
            component = (TKey) c;

            return true;
        }

        component = default;

        return false;
    }
}