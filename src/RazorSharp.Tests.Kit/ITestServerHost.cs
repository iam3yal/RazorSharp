namespace RazorSharp.Tests.Kit;

public interface ITestServerHost : IDisposable
{
    string ServerAddress { get; }
}