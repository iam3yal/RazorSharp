namespace RazorSharp.JSInterop;

using Microsoft.AspNetCore.Components;

public interface IJSModuleInfo
{
    static abstract string FileName { get; }

    public ElementReference Element { get; }

    public string Path { get; }
}