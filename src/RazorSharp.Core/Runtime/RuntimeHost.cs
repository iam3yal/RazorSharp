namespace RazorSharp.Core.Runtime;

public static class RuntimeHost
{
    public static bool IsClientSide
        => OperatingSystem.IsBrowser();

    public static bool IsServerSide
        => !OperatingSystem.IsBrowser();
}