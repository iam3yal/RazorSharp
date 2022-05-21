namespace RazorSharp.Core.Diagnostics;

using System.Diagnostics;

public sealed class DebugConfiguration : IBuildConfigurationProvider
{
    private string _debugString = "";

    // NOTE: Makes sure the compiler doesn't mark the type with beforefieldinit
    static DebugConfiguration()
    {
    }

    private DebugConfiguration()
    {
    }

    public static DebugConfiguration Instance { get; } = new ();

    public string GetBuildConfigurationString()
    {
        SetDebugFlag();

        return _debugString;
    }

    [Conditional("DEBUG")]
    private void SetDebugFlag()
        => _debugString = "DEBUG";
}