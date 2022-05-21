namespace RazorSharp.Core.Contracts;

public static class PostconditionTests
{
    public static class IsFalse
    {
        [Fact]
        public static void Should_not_throw_when_is_false()
        {
            var ex = Record.Exception(() => Postcondition.IsFalse(false));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_true()
        {
            Assert.ThrowsAny<Postcondition.AssertException>(() => Postcondition.IsFalse(true));
        }
    }

    public static class IsNotEmpty
    {
        [Fact]
        public static void Should_not_throw_when_is_not_empty()
        {
            var ex = Record.Exception(() => Postcondition.IsNotEmpty("foo"));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_empty()
        {
            Assert.Throws<Postcondition.AssertException>(() => Postcondition.IsNotEmpty(""));
        }
    }

    public static class IsNotNull
    {
        [Fact]
        public static void Should_not_throw_when_is_not_null()
        {
            var ex = Record.Exception(() => Postcondition.IsNotNull(""));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_null()
        {
            Assert.Throws<Postcondition.AssertException>(() => Postcondition.IsNotNull<string>(null));
        }
    }

    public static class IsTrue
    {
        [Fact]
        public static void Should_not_throw_when_is_true()
        {
            var ex = Record.Exception(() => Postcondition.IsTrue(true));

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_throw_when_is_false()
        {
            Assert.ThrowsAny<Postcondition.AssertException>(() => Postcondition.IsTrue(false));
        }
    }
}