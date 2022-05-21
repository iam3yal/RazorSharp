namespace RazorSharp.JSInterop;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using RazorSharp.Core.Contracts;

public static class JSRuntimeExtensions
{
    public static async ValueTask<TValue> CreateInstanceAsyncAs<TValue>(this IJSRuntime jsRuntime,
                                                                        ElementReference elementRef)
        where TValue : IJSModuleActivator<TValue>, IJSModuleInfo
    {
        Precondition.IsNotNull(jsRuntime);
        Precondition.IsNotEmpty(elementRef.Id);

        var path = JSInteropPath.CreatePath(TValue.FileName);

        var jsModuleRef = await jsRuntime.InvokeAsync<IJSObjectReference>("import", path);

        var jsModuleInstanceRef =
            await jsModuleRef.InvokeAsync<IJSObjectReference>(JSConstants.CreateInstanceIdentifier<TValue>());

        return TValue.Create(new JSModuleReference(jsModuleInstanceRef, path), elementRef);
    }

    [SuppressMessage("ReSharper", "HeapView.ObjectAllocation")]
    public static async ValueTask<JSModuleReference> CreateModuleAsync(this IJSRuntime jsRuntime,
                                                                       string path)
    {
        Precondition.IsNotNull(jsRuntime);
        Precondition.IsNotEmpty(path);

        var jsModuleRef = await jsRuntime.InvokeAsync<IJSObjectReference>("import", path);

        return new (jsModuleRef, path);
    }

    public static async ValueTask<TValue> CreateModuleAsyncAs<TValue>(this IJSRuntime jsRuntime,
                                                                      ElementReference elementRef)
        where TValue : IJSModuleActivator<TValue>, IJSModuleInfo
    {
        Precondition.IsNotNull(jsRuntime);
        Precondition.IsNotEmpty(elementRef.Id);

        var path = JSInteropPath.CreatePath(TValue.FileName);

        var moduleRef = await CreateModuleAsync(jsRuntime, path);

        return TValue.Create(moduleRef, elementRef);
    }
}