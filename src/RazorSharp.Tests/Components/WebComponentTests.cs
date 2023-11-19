namespace RazorSharp.Components;

public sealed class WebComponentTests
{
    public class Dispose : TestContext
    {
        [Fact]
        public void Should_never_throw_on_subsequent_calls()
        {
            var webInputRef = RenderComponent<WebComponent>().Instance;

            var ex = Record.Exception(() => {
                ((IDisposable) webInputRef).Dispose();
                ((IDisposable) webInputRef).Dispose();
            });

            Assert.Null(ex);
        }

        [Fact]
        public void Should_not_set_IsDisposed_to_true()
        {
            var webInputRef = RenderComponent<WebComponent>().Instance;

            ((IDisposable) webInputRef).Dispose();

            Assert.False(webInputRef.IsDisposed);
        }
    }

    public class DisposeAsync : TestContext

    {
        [Fact]
        public async Task Should_never_throw_on_subsequent_calls()
        {
            var webInputRef = RenderComponent<WebComponent>().Instance;

            var ex = await Record.ExceptionAsync(async () => {
                await webInputRef.DisposeAsync();
                await webInputRef.DisposeAsync();
            });

            Assert.Null(ex);
        }

        [Fact]
        public async Task Should_set_IsDisposed_to_true()
        {
            var webInputRef = RenderComponent<WebComponent>().Instance;

            await webInputRef.DisposeAsync();

            Assert.True(webInputRef.IsDisposed);
        }
    }
}