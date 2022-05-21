namespace RazorSharp.JSInterop;

public static class JSInteropPath
{
    private const string JSEmbeddedScriptPath = "./_content/RazorSharp.Components";

    public static string CreatePath(ReadOnlySpan<char> filename)
    {
        var path = Path.Join(JSEmbeddedScriptPath, filename);

        return $"{path}.mjs";
    }
}