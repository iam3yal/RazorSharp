namespace RazorSharp.Core.Strings;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public ref struct SeparatorValueEnumerator
{
    private readonly ReadOnlySpan<char> _separator;

    private ReadOnlySpan<char> _value;

    private SeparatorValueEnumerator(ReadOnlySpan<char> value, ReadOnlySpan<char> separator)
    {
        _value = value;

        _separator = separator;

        Current = default;
    }

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public ReadOnlySpan<char> Current { get; private set; }

    public static SeparatorValueEnumerator GetValues(string value, ReadOnlySpan<char> separator)
        => new (value.AsSpan(), separator);

    public SeparatorValueEnumerator GetEnumerator()
        => this;

    public bool MoveNext()
    {
        var span = _value;

        if (span.Length == 0)
        {
            return false;
        }

        var index = span.IndexOfAny(_separator);

        if (index == -1)
        {
            _value = ReadOnlySpan<char>.Empty;

            Current = span;

            return true;
        }

        Current = span[..index];

        _value = span[(index + 1)..];

        return true;
    }
}