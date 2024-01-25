namespace RazorSharp.JSInterop;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IJSModuleInfo
{
    static abstract string FileName { get; }

    public ElementReference Element { get; }

    public string Path { get; }
}