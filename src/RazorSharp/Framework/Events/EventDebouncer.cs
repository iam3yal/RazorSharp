namespace RazorSharp.Framework.Events;

public sealed class EventDebouncer<T> : IDebounceable<T>, IAsyncDisposable
    where T : class
{
    private CancellationTokenSource? _cts;

    public async ValueTask DebounceAsync(Func<T, Task> func, T arg, int interval)
    {
        if (_cts is not null)
        {
            await _cts.CancelAsync();
        }

        _cts = new CancellationTokenSource();

        await Task.Delay(interval, _cts.Token)
                  .ContinueWith(async t => {
                      if (t.IsCompletedSuccessfully)
                      {
                          await func(arg);
                          await DisposeAsync();
                      }
                  });
    }

    public async ValueTask DisposeAsync()
    {
        _cts?.Dispose();
        _cts = null;

        await ValueTask.CompletedTask;
    }
}