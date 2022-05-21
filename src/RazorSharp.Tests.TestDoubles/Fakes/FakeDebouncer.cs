namespace RazorSharp.Tests.TestDoubles.Fakes;

using RazorSharp.Framework.Events;

public sealed class FakeDebouncer<T> : IDebounceable<T>, IAsyncDisposable
    where T : class
{
    public async ValueTask DebounceAsync(Func<T, Task> func, T argument, int interval)
        => await func(argument);

    public ValueTask DisposeAsync()
        => ValueTask.CompletedTask;
}