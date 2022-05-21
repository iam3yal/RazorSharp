namespace RazorSharp.Tests.TestDoubles.Customizations;

using RazorSharp.Tests.Kit._Moq;

public sealed class JSInProcessObjectReferenceCustomization : ICustomization<IJSInProcessObjectReference>
{
    private Func<Exception>? _exceptionActivator;

    public void Configure(Mock<IJSInProcessObjectReference> mock)
    {
        mock.Setup(x =>
                       x.Invoke<object>(It.IsAny<string>(), It.IsAny<object?[]?>()))
            .Returns(new object());

        mock.Setup(x =>
                       x.InvokeAsync<object>(It.IsAny<string>(), It.IsAny<object?[]?>()))
            .Returns(default(ValueTask<object>));

        if (_exceptionActivator is not null)
        {
            mock.Setup(x =>
                           x.DisposeAsync())
                .Throws(() => _exceptionActivator());
        }
    }

    public JSInProcessObjectReferenceCustomization Throw(Func<Exception> exceptionActivator)
    {
        _exceptionActivator = exceptionActivator;

        return this;
    }
}