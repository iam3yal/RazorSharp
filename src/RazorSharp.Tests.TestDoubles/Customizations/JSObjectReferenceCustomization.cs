namespace RazorSharp.Tests.TestDoubles.Customizations;

using RazorSharp.Tests.Kit._Moq;

public sealed class JSObjectReferenceCustomization : ICustomization<IJSObjectReference>
{
    private IJSObjectReference? _jsObjectRef;

    public void Configure(Mock<IJSObjectReference> mock)
    {
        mock.Setup(x =>
                       x.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object?[]?>()))
            .Returns(default(ValueTask<object>));

        mock.Setup(x =>
                       x.InvokeAsync<IJSObjectReference?>(It.IsAny<string>(), It.IsAny<object?[]?>()))
            .ReturnsAsync(_jsObjectRef);
    }

    public JSObjectReferenceCustomization SetInvokeAsyncResult()
    {
        _jsObjectRef = Fake
                       .Create(this)
                       .Build();

        return this;
    }
}

public sealed class JSObjectReferenceCustomization<T> : ICustomization<IJSObjectReference>
    where T : class, new()
{
    public void Configure(Mock<IJSObjectReference> mock)
    {
        mock.Setup(x =>
                       x.InvokeAsync<T>(It.IsAny<string>(), It.IsAny<object?[]?>()))
            .Returns(default(ValueTask<T>));
    }
}