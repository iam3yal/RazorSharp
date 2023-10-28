extern alias E2EServerApp;

namespace RazorSharp;

using RazorSharp.Tests.Kit;

public sealed class TestServerHostFixture : ITestServerHost
{
    private readonly ITestServerHost _testServerHost = new TestServerHostFactory<E2EServerApp::Program>();

    public string ServerAddress
        => _testServerHost.ServerAddress;

    public void Dispose()
        => _testServerHost.Dispose();
}