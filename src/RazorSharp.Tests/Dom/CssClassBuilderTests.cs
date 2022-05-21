namespace RazorSharp.Dom;

public static class CssClassBuilderTests
{
    public static class Append
    {
        [Fact]
        public static void Should_append_another_builder()
        {
            var @class = new CssClassBuilder()
                         .Append(new CssClassBuilder().Append("bar"))
                         .ToString();

            Assert.Equal("bar", @class);
        }

        [Fact]
        public static void Should_append_class_name()
        {
            var @class = new CssClassBuilder()
                         .Append("foo")
                         .ToString();

            Assert.Equal("foo", @class);
        }

        [Fact]
        public static void Should_append_class_name_only_when_condition_is_met()
        {
            var @class = new CssClassBuilder()
                         .AppendWhen("on", true)
                         .AppendWhen("off", false)
                         .ToString();

            Assert.Equal("on", @class);
        }

        [Fact]
        public static void Should_append_multiple_class_names()
        {
            var @class = new CssClassBuilder()
                         .Append("foo")
                         .Append("bar")
                         .ToString();

            Assert.Equal("foo bar", @class);
        }

        [Fact]
        public static void Should_not_append_when_is_empty()
        {
            var @class = new CssClassBuilder().Append("");

            Assert.True(@class.IsEmpty);
        }

        [Fact]
        public static void Should_not_throw_when_class_names_contains_valid_characters()
        {
            var ex = Record.Exception(() => {
                new CssClassBuilder()
                    .Append("abcdefghijklmnopqrstuvwxyz")
                    .Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                    .Append("X01234567890")
                    .Append("_ -");
            });

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_perform_action_only_when_condition_is_met()
        {
            var @class = new CssClassBuilder()
                         .When(true, it => it.Append("on"))
                         .When(false, it => it.Append("off"))
                         .ToString();

            Assert.Equal("on", @class);
        }

        [Fact]
        public static void Should_throw_when_class_name_contains_invalid_characters()
        {
            Assert.Throws<ArgumentException>(() => new CssClassBuilder()
                                                 .Append("foo!"));
        }

        [Fact]
        public static void Should_throw_when_class_name_start_with_number()
        {
            Assert.Throws<ArgumentException>(() => new CssClassBuilder()
                                                 .Append("0"));
        }
    }

    public new static class ToString
    {
        [Fact]
        public static void Should_empty_builder()
        {
            var classBuilder = new CssClassBuilder().Append("foo");
            var @class = classBuilder.ToString();

            Assert.Multiple(() => Assert.Equal("foo", @class),
                            () => Assert.True(classBuilder.IsEmpty))
                ;
        }
    }
}