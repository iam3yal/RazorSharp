namespace RazorSharp.Components;

using RazorSharp.Tests.Kit;

public static class WebComponentTests
{
    public static class Dispose
    {
        [Fact]
        public static void Should_never_throw_on_subsequent_calls()
        {
            using var ctx = new RazorSharpTestContext();

            var webInput = ctx.RenderComponent<WebComponent>()
                              .Instance;

            var ex = Record.Exception(() => {
                ((IDisposable) webInput).Dispose();
                ((IDisposable) webInput).Dispose();
            });

            Assert.Null(ex);
        }

        [Fact]
        public static void Should_not_set_IsDisposed_to_true()
        {
            using var ctx = new RazorSharpTestContext();

            var webInput = ctx.RenderComponent<WebComponent>()
                              .Instance;

            ((IDisposable) webInput).Dispose();

            Assert.False(webInput.IsDisposed);
        }
    }

    public static class DisposeAsync
    {
        [Fact]
        public static async Task Should_never_throw_on_subsequent_calls()
        {
            using var ctx = new RazorSharpTestContext();

            var webInput = ctx.RenderComponent<WebComponent>()
                              .Instance;

            var ex = await Record.ExceptionAsync(async () => {
                await webInput.DisposeAsync();
                await webInput.DisposeAsync();
            });

            Assert.Null(ex);
        }

        [Fact]
        public static async Task Should_set_IsDisposed_to_true()
        {
            using var ctx = new RazorSharpTestContext();

            var webInput = ctx.RenderComponent<WebComponent>()
                              .Instance;

            await webInput.DisposeAsync();

            Assert.True(webInput.IsDisposed);
        }
    }
}