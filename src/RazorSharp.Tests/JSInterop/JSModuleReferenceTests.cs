namespace RazorSharp.JSInterop;

using RazorSharp.Tests.Kit._Moq;
using RazorSharp.Tests.TestDoubles.Customizations;
using RazorSharp.Tests.TestDoubles.Fakes;

public static class JSModuleReferenceTests
{
    public static class DisposeAsync
    {
        [Fact]
        public static async Task Should_handle_JSDisconnectedException_when_disposed()
        {
            var jsInProcessObjectReference = Fake
                                             .Create(new JSInProcessObjectReferenceCustomization()
                                                         .Throw(() => new JSDisconnectedException("")))
                                             .Build();

            var jsModuleReference = new JSModuleReference(jsInProcessObjectReference, "foo");

            var ex = await Record.ExceptionAsync(async () => {
                await jsModuleReference.DisposeAsync();
            });

            Assert.IsType<JSDisconnectedException>(ex);
        }

        [Fact]
        public static async Task Should_never_throw_on_subsequent_calls()
        {
            var jsInProcessObjectReference = Fake
                                             .Create(new JSInProcessObjectReferenceCustomization())
                                             .Build();

            var jsModuleReference = new JSModuleReference(jsInProcessObjectReference, "foo");

            var ex = await Record.ExceptionAsync(async () => {
                await jsModuleReference.DisposeAsync();
                await jsModuleReference.DisposeAsync();
            });

            Assert.Null(ex);
        }

        [Fact]
        public static async Task Should_swallow_JSDisconnectedException_when_build_configuration_is_release()
        {
            var jsInProcessObjectReference = Fake
                                             .Create(new JSInProcessObjectReferenceCustomization()
                                                         .Throw(() => new JSDisconnectedException("")))
                                             .Build();

            var jsModuleReference = new JSModuleReference(jsInProcessObjectReference, "foo")
            {
                BuildConfiguration = new FakeReleaseConfiguration()
            };

            var ex = await Record.ExceptionAsync(async () => {
                await jsModuleReference.DisposeAsync();
            });

            Assert.Null(ex);
        }
    }
}