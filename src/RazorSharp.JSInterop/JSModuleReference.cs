namespace RazorSharp.JSInterop;

using System.Diagnostics.CodeAnalysis;

using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

using RazorSharp.Core.Contracts;
using RazorSharp.Core.Diagnostics;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "HeapView.ObjectAllocation")]
public sealed class JSModuleReference : IJSObjectReference
{
    private readonly IJSObjectReference _moduleRef;

    public JSModuleReference(IJSObjectReference moduleRef, string path)
    {
        Precondition.IsNotNull(moduleRef);
        Precondition.IsNotEmpty(path);

        _moduleRef = moduleRef;

        Path = path;
    }

    public string Path { get; }

    internal IBuildConfigurationProvider BuildConfiguration { private get; set; }
        = DebugConfiguration.Instance;

    [SuppressMessage("Usage", "CA2254:Template should be a static expression")]
    public async ValueTask DisposeAsync()
    {
        try
        {
            await _moduleRef.DisposeAsync();
        }
        catch (JSDisconnectedException ex)
        {
            if (BuildConfiguration.Is("DEBUG"))
            {
                throw new JSDisconnectedException(
                    $"{ex.GetType()}:\n {ex.Message}\n  at {GetType()}.{nameof(DisposeAsync)}:\n   Module Path: {Path}\n");
            }
        }
    }

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        => await _moduleRef.InvokeAsync<TValue>(identifier, args);

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg)
        => await _moduleRef.InvokeAsync<TValue>(identifier, arg);

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0, object? arg1)
        => await _moduleRef.InvokeAsync<TValue>(identifier, arg0, arg1);

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0, object? arg1, object? arg2)
        => await _moduleRef.InvokeAsync<TValue>(identifier, arg0, arg1, arg2);

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier,
                                                       CancellationToken cancellationToken,
                                                       object?[]? args)
        => await _moduleRef.InvokeAsync<TValue>(identifier, cancellationToken, args);

    public async ValueTask InvokeVoidAsync(string identifier, params object?[]? args)
        => await _moduleRef.InvokeAsync<IJSVoidResult>(identifier, args);

    public async ValueTask InvokeVoidAsync(string identifier, object? arg)
        => await _moduleRef.InvokeAsync<IJSVoidResult>(identifier, arg);

    public async ValueTask InvokeVoidAsync(string identifier, object? arg0, object? arg1)
        => await _moduleRef.InvokeAsync<IJSVoidResult>(identifier, arg0, arg1);

    public async ValueTask InvokeVoidAsync(string identifier, object? arg0, object? arg1, object? arg2)
        => await _moduleRef.InvokeAsync<IJSVoidResult>(identifier, arg0, arg1, arg2);
}