namespace RazorSharp.JSInterop;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

public interface IJSModuleActivator<out T> : IAsyncDisposable
{
    [SuppressMessage("Design", "CA1000:Do not declare static members on generic types",
                     Justification = "Factory method")]
    static abstract T Create(JSModuleReference moduleRef, ElementReference elementRef);
}