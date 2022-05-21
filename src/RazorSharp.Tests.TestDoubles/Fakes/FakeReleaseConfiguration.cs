namespace RazorSharp.Tests.TestDoubles.Fakes;

using RazorSharp.Core.Diagnostics;

public sealed class FakeReleaseConfiguration : IBuildConfigurationProvider
{
    public string GetBuildConfigurationString()
        => "RELEASE";
}