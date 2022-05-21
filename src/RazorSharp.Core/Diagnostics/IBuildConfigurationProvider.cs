namespace RazorSharp.Core.Diagnostics;

public interface IBuildConfigurationProvider
{
    string GetBuildConfigurationString();

    public bool Is(string configuration)
        => GetBuildConfigurationString() == configuration;
}