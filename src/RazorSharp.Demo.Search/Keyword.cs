namespace RazorSharp.Demo.Search;

public readonly ref struct Keyword
{
    private readonly ReadOnlySpan<char> _keyword;

    public Keyword(ReadOnlySpan<char> value)
    {
        _keyword = value;

        var colonIndex = value.IndexOf(':');

        if (colonIndex > -1)
        {
            Name = value[..colonIndex];

            Name = Name.Trim();

            Value = value[(colonIndex + 1)..];
        }
        else
        {
            Value = value;
        }

        if (!Value.IsEmpty)
        {
            Value = Value.Trim();
        }
    }

    public bool HasName
        => !Name.IsEmpty;

    public bool HasValue
        => !Value.IsEmpty;

    public ReadOnlySpan<char> Name { get; }

    public ReadOnlySpan<char> Value { get; }

    public override string ToString()
        => _keyword.ToString();
}