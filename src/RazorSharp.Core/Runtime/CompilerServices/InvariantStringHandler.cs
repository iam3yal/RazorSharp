namespace RazorSharp.Core.Runtime.CompilerServices;

using System.Globalization;
using System.Runtime.CompilerServices;

[InterpolatedStringHandler]
public ref struct InvariantStringHandler
{
    private DefaultInterpolatedStringHandler _identifier;

    public InvariantStringHandler(int literalLength, int formattedCount)
        => _identifier = new (literalLength, formattedCount, CultureInfo.InvariantCulture);

    public void AppendFormatted<T>(T t)
        => _identifier.AppendFormatted(t);

    public void AppendFormatted(ReadOnlySpan<char> value)
        => _identifier.AppendFormatted(value);

    public void AppendLiteral(string s)
        => _identifier.AppendLiteral(s);

    public override string ToString()
        => _identifier.ToStringAndClear();
}