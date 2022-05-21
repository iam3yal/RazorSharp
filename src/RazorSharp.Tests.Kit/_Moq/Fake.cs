namespace RazorSharp.Tests.Kit._Moq;

using RazorSharp.Core.Contracts;

public sealed partial class Fake
{
    public static FakeBuilder<T> Create<T>()
        where T : class
        => new ();

    public static FakeBuilder<T> Create<T>(ICustomization<T> customization)
        where T : class
    {
        Precondition.IsNotNull(customization);

        return new FakeBuilder<T>().Customize(customization);
    }
}