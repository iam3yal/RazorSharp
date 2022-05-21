namespace RazorSharp.Core.Contracts;

public static class PreconditionTests
{
    public static class IsInRange
    {
        [Fact]
        public static void Should_not_throw_when_is_true()
        {
            var ex = Record.Exception(() => Precondition.IsInRange(true));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_false()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.IsInRange(false));
        }
    }

    public static class IsNotEmpty
    {
        [Fact]
        public static void Should_not_throw_when_is_not_empty()
        {
            var ex = Record.Exception(() => Precondition.IsNotEmpty("foo"));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_empty()
        {
            Assert.Throws<ArgumentException>(() => Precondition.IsNotEmpty(""));
        }
    }

    public static class IsNotNull
    {
        [Fact]
        public static void Should_not_throw_when_is_not_null()
        {
            var ex = Record.Exception(() => Precondition.IsNotNull<string>(""));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => Precondition.IsNotNull<string>(null));
        }
    }
}