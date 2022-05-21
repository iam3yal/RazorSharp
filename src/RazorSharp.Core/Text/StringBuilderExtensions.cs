namespace RazorSharp.Core.Text;

using System.Text;

using RazorSharp.Core.Contracts;

public static class StringBuilderExtensions
{
    public static bool Contains(this StringBuilder source, ReadOnlySpan<char> value)
    {
        Precondition.IsNotNull(source);

        if (value.IsEmpty)
        {
            return true;
        }

        if (source.Length is 0)
        {
            return false;
        }

        var valueIndex = 0;

        foreach (var chunk in source.GetChunks())
        {
            foreach (var @char in chunk.Span)
            {
                if (value[valueIndex] == @char)
                {
                    valueIndex++;
                }
                else
                {
                    valueIndex = 0;
                }

                if (valueIndex == value.Length)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static int IndexOf(this StringBuilder source, ReadOnlySpan<char> value, int startIndex = 0)
    {
        Precondition.IsNotNull(source);
        Precondition.IsInRange(startIndex > -1);

        if (value.IsEmpty)
        {
            return 0;
        }

        if (source.Length is 0)
        {
            return -1;
        }

        var index = -1;
        var valueIndex = 0;
        var firstMatchIndex = -1;

        foreach (var chunk in source.GetChunks())
        {
            foreach (var @char in chunk.Span)
            {
                index++;

                if (index < startIndex)
                {
                    continue;
                }

                if (value[valueIndex] == @char)
                {
                    valueIndex++;

                    if (firstMatchIndex == -1)
                    {
                        firstMatchIndex = index;
                    }
                }
                else
                {
                    valueIndex = 0;
                    firstMatchIndex = -1;
                }

                if (valueIndex == value.Length)
                {
                    return firstMatchIndex;
                }
            }
        }

        return firstMatchIndex;
    }
}