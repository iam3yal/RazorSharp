namespace RazorSharp.JSInterop;

using Microsoft.AspNetCore.Components;

public interface IJSModuleActivator<out T> : IAsyncDisposable
{
    static abstract T Create(JSModuleReference moduleRef, ElementReference elementRef);
}