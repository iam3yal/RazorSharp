namespace RazorSharp.Core.Components;

using Microsoft.AspNetCore.Components;

public static class MarkupConsole
{
    public static MarkupString WriteLine(string value)
    {
        Console.WriteLine(value);

        return Markup.Empty;
    }
}