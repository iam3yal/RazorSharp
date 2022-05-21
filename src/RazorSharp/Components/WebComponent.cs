namespace RazorSharp.Components;

[SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize")]
public class WebComponent : ComponentBase, IDisposable, IAsyncDisposable
{
    public bool IsDisposed { get; private set; }

    [NotNull]
    [Inject]
    protected IJSRuntime? JSRuntime { get; set; }

    public async ValueTask DisposeAsync()
    {
        await OnDisposeAsync();

        ((IDisposable) this).Dispose();

        IsDisposed = true;
    }

    // NOTE: Consumers should never call the sync version of Dispose explicitly.
    void IDisposable.Dispose()
        => OnDispose();

    protected virtual void OnDispose()
    {
    }

    protected virtual async ValueTask OnDisposeAsync()
        => await ValueTask.CompletedTask;
}