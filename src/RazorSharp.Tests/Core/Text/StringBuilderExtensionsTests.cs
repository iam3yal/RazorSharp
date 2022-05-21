namespace RazorSharp.Core.Text;

using RazorSharp.Tests.TestDoubles.Fixtures;

public static class StringBuilderExtensionsTests
{
    public sealed class Contains : IClassFixture<StringBuilderFixture>
    {
        private readonly StringBuilderFixture _fixture;

        public Contains(StringBuilderFixture fixture)
            => _fixture = fixture;

        [Fact]
        public void Should_return_false_when_a_line_break_exists_between_two_characters()
        {
            _fixture.AppendLoremIpsumText();

            Assert.False(_fixture.StringBuilder.Contains("lF"));
        }

        [Fact]
        public void Should_return_false_when_value_was_not_found()
        {
            _fixture.AppendLoremIpsumText();

            Assert.False(_fixture.StringBuilder.Contains("eros"));
        }

        [Fact]
        public void Should_return_true_when_value_is_empty()
        {
            Assert.True(_fixture.StringBuilder.Contains(""));
        }

        [Theory]
        [InlineData("orem")]
        [InlineData("elit")]
        [InlineData("Nullam")]
        [InlineData("tN")]
        [InlineData("semper, ullamcorper")]
        [InlineData("interdum")]
        public void Should_return_true_when_value_was_found(string value)
        {
            _fixture.AppendLoremIpsumText();

            Assert.True(_fixture.StringBuilder.Contains(value));
        }
    }

    public sealed class IndexOf : IClassFixture<StringBuilderFixture>
    {
        private readonly StringBuilderFixture _fixture;

        public IndexOf(StringBuilderFixture fixture)
            => _fixture = fixture;

        [Fact]
        public void Should_minus_one_when_value_was_not_found()
        {
            _fixture.AppendLoremIpsumText();

            Assert.Equal(-1, _fixture.StringBuilder.IndexOf("eros"));
        }

        [Fact]
        public void Should_return_minus_one_when_a_line_break_exists_between_two_characters()
        {
            _fixture.AppendLoremIpsumText();

            Assert.Equal(-1, _fixture.StringBuilder.IndexOf("lF"));
        }

        [Theory]
        [InlineData("orem", 0, 0)]
        [InlineData("dolor", 9, 11)]
        [InlineData("rem", 9, -1)]
        public void Should_return_valid_index_when_startIndex_is_passed(string value, int startIndex, int expectedIndex)
        {
            _fixture.AppendLoremIpsumText();

            Assert.Equal(expectedIndex, _fixture.StringBuilder.IndexOf(value, startIndex));
        }

        [Theory]
        [InlineData("orem", 0)]
        [InlineData("rem", 1)]
        [InlineData("f", 136)]
        [InlineData("F", 115)]
        [InlineData("tN", 53)]
        [InlineData("semper, ullamcorper", 70)]
        [InlineData("interdum", 150)]
        public void Should_return_valid_index_when_value_is_found(string value, int expectedIndex)
        {
            _fixture.AppendLoremIpsumText();

            Assert.Equal(expectedIndex, _fixture.StringBuilder.IndexOf(value));
        }

        [Theory]
        [InlineData(0, 27)]
        [InlineData(25, 27)]
        [InlineData(27, 27)]
        [InlineData(28, -1)]
        public void Should_return_valid_index_when_word_is_chunked(int startIndex, int expectedIndex)
        {
            _fixture.AppendChunkedLoremIpsumText();

            Assert.Equal(expectedIndex, _fixture.StringBuilder.IndexOf("consectetur", startIndex));
        }

        [Fact]
        public void Should_return_zero_when_value_is_empty()
        {
            Assert.Equal(0, _fixture.StringBuilder.IndexOf(""));
        }
    }
}