namespace RazorSharp.Demo.Search;

using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

public partial class KeywordParser
{
    public static KeywordEnumerator Parse(ReadOnlySpan<char> value)
        => KeywordEnumerator.GetValues(value);

    [GeneratedRegex(@"(?:\w+:\s*[^;]|[^;])+",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline)]
    private static partial Regex GetKeyword();

    public ref struct KeywordEnumerator
    {
        private readonly ReadOnlySpan<char> _value;

        private Regex.ValueMatchEnumerator _iterator;

        private KeywordEnumerator(ReadOnlySpan<char> value)
        {
            _value = value;

            _iterator = GetKeyword().EnumerateMatches(value);
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        public Keyword Current
        {
            get
            {
                var matchedValue = _iterator.Current;
                var slicedValue = _value.Slice(matchedValue.Index, matchedValue.Length);

                return new Keyword(slicedValue);
            }
        }

        public static KeywordEnumerator GetValues(ReadOnlySpan<char> value)
            => new (value);

        public KeywordEnumerator GetEnumerator()
            => this;

        public bool MoveNext()
            => _iterator.MoveNext();
    }
}