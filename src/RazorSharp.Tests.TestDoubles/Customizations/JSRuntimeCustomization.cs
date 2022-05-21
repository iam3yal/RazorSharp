namespace RazorSharp.Tests.TestDoubles.Customizations;

using RazorSharp.Tests.Kit._Moq;

public sealed class JSRuntimeCustomization : ICustomization<IJSRuntime>
{
    private IJSObjectReference? _jsObjectRef;

    public void Configure(Mock<IJSRuntime> mock)
    {
        if (_jsObjectRef is IJSInProcessObjectReference jsInProcessObjectReference)
        {
            mock.Setup(x =>
                           x.InvokeAsync<IJSInProcessObjectReference>(It.IsAny<string>(), It.IsAny<object?[]?>())
                            .Result)
                .Returns(jsInProcessObjectReference);
        }
        else if (_jsObjectRef is not null)
        {
            mock.Setup(x =>
                           x.InvokeAsync<IJSObjectReference>(It.IsAny<string>(), It.IsAny<object?[]?>()).Result)
                .Returns(_jsObjectRef);
        }
    }

    public JSRuntimeCustomization SetInvokeAsyncResult(ICustomization<IJSInProcessObjectReference> customization)
    {
        _jsObjectRef = Fake
                       .Create(customization)
                       .Build();

        return this;
    }

    public JSRuntimeCustomization SetInvokeAsyncResult(ICustomization<IJSObjectReference> customization)
    {
        _jsObjectRef = Fake
                       .Create(customization)
                       .Build();

        return this;
    }
}