namespace RazorSharp.JSInterop;

using RazorSharp.Tests.Kit._Moq;
using RazorSharp.Tests.TestDoubles.Customizations;
using RazorSharp.Tests.TestDoubles.Fakes;

public static class JSRuntimeExtensionsTests
{
    public static class CreateInstanceAsyncAs
    {
        [Fact]
        public static async Task Should_return_instance_of_JSModuleFake()
        {
            var jsRuntime = Fake
                            .Create(new JSRuntimeCustomization()
                                        .SetInvokeAsyncResult(new JSObjectReferenceCustomization()
                                                                  .SetInvokeAsyncResult()))
                            .Build();

            var instance = await jsRuntime.CreateInstanceAsyncAs<FakeJSModule>(FakeElementReferenceFactory.Create());

            Assert.Multiple(() => Assert.NotNull(instance),
                            () => Assert.IsType<FakeJSModule>(instance));
        }
    }

    public static class CreateModuleAsync
    {
        [Fact]
        public static async Task Should_return_instance_of_JSModuleReference()
        {
            var jsRuntime = Fake
                            .Create(new JSRuntimeCustomization()
                                        .SetInvokeAsyncResult(new JSObjectReferenceCustomization()))
                            .Build();

            var instance = await jsRuntime.CreateModuleAsync("./_content/RazorSharp.Components/foo.mjs");

            Assert.Multiple(() => Assert.NotNull(instance),
                            () => Assert.IsType<JSModuleReference>(instance));
        }
    }

    public static class CreateModuleAsyncAs
    {
        [Fact]
        public static async Task Should_return_instance_of_JSModuleFake()
        {
            var jsRuntime = Fake
                            .Create(new JSRuntimeCustomization()
                                        .SetInvokeAsyncResult(new JSObjectReferenceCustomization()))
                            .Build();

            var instance = await jsRuntime.CreateModuleAsyncAs<FakeJSModule>(FakeElementReferenceFactory.Create());

            Assert.Multiple(() => Assert.NotNull(instance),
                            () => Assert.IsType<FakeJSModule>(instance));
        }
    }
}