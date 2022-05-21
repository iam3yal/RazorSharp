namespace RazorSharp.Demo.Search;

using System.Text;

using RazorSharp.Core.Text;

public static class SearchInputMatcher
{
    // REMARK: It might have been better to use/do some sort of Csv Parser but for the sake of the demo it doesn't really matter.

    public static bool IsMatch(StringBuilder input, string value)
        => IsMatch(input, value.AsSpan());

    public static bool IsMatch(StringBuilder input, ReadOnlySpan<char> value)
    {
        var contains = false;

        Span<char> loweredValue = stackalloc char[value.Length];

        value.ToLowerInvariant(loweredValue);

        foreach (var keyword in KeywordParser.Parse(value))
        {
            if (keyword.HasName)
            {
                var nameIndex = input.IndexOf(keyword.Name);

                if (nameIndex > -1 && keyword.HasValue)
                {
                    var valueSeparatorIndex = nameIndex + keyword.Name.Length + 1;

                    contains = IsValueWithinBounds(keyword.Value, valueSeparatorIndex, true);
                }
                else
                {
                    contains = false;
                }
            }
            else if (keyword.HasValue)
            {
                var valueSeparatorIndex = input.IndexOf(":");

                while (valueSeparatorIndex > -1)
                {
                    contains = IsValueWithinBounds(keyword.Value, valueSeparatorIndex, false);

                    if (contains)
                    {
                        break;
                    }

                    valueSeparatorIndex = input.IndexOf(":", valueSeparatorIndex + 1);
                }
            }

            if (!contains)
            {
                break;
            }
        }

        return contains;

        bool IsValueWithinBounds(ReadOnlySpan<char> keywordValue,
                                 int valueSeparatorIndex,
                                 bool shouldStartDirectlyAfterSeparator)
        {
            var valueIndex = input.IndexOf(keywordValue, valueSeparatorIndex);

            if (valueIndex > -1)
            {
                var isValueAfterSeparator =
                    !shouldStartDirectlyAfterSeparator || valueIndex - valueSeparatorIndex == 0;
                var keywordSeparatorIndex = -1;

                for (var i = valueSeparatorIndex; i < input.Length; i++)
                {
                    if (input[i] == ';')
                    {
                        keywordSeparatorIndex = i;
                        break;
                    }
                }

                return isValueAfterSeparator && valueIndex < keywordSeparatorIndex;
            }

            return false;
        }
    }
}