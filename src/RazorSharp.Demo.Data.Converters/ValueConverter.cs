namespace RazorSharp.Demo.Data.Converters;

using RazorSharp.Core.Contracts;

public static class ValueConverter
{
    public static ReadOnlySpan<char> ToLowerString(object? value)
    {
        Precondition.IsNotNull(value);

        return value switch
        {
            string x => x.ToLower(),
            _        => ToString(value)
        };
    }

    public static string ToString(object? value)
    {
        Precondition.IsNotNull(value);

        return value switch
        {
            string x   => x,
            int x      => x.ToString(),
            decimal x  => DecimalConverter.ToString(x),
            DateOnly x => DateOnlyConverter.ToString(x),
            DateTime x => DateTimeConverter.ToString(x),
            _          => throw new InvalidOperationException($"Not supported type '{value.GetType()}'.")
        };
    }
}