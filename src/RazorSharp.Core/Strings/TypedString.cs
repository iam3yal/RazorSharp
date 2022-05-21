namespace RazorSharp.Core.Strings;

using RazorSharp.Core.Contracts;

public abstract record TypedString<T>
    where T : TypedString<T>
{
    private readonly string _value;

    protected TypedString(string value)
    {
        Precondition.IsNotNull(value);

        _value = value;
    }

    public static implicit operator string(TypedString<T> type)
        => type._value;

    public sealed override string ToString()
        => _value;
}