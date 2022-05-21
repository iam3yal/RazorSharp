namespace RazorSharp.Tests.Kit._Moq;

public interface ICustomization<T>
    where T : class
{
    void Configure(Mock<T> mock);
}