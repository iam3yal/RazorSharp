namespace RazorSharp.Tests.Kit;

using RazorSharp.Core.Contracts;

public static class TestServerHostExtensions
{
    public static string GetFullPageAddress(this ITestServerHost host, string page)
    {
        Precondition.IsNotNull(host);
        Precondition.IsNotEmpty(page);

        return $"{host.ServerAddress}/{page}";
    }
}