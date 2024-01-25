namespace RazorSharp.Core.Components;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class MarkupConsole
{
    public static MarkupString WriteLine(string value)
    {
        Console.WriteLine(value);

        return Markup.Empty;
    }
}