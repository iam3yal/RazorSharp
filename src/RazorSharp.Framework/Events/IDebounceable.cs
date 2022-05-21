namespace RazorSharp.Framework.Events;

public interface IDebounceable<T>
    where T : class
{
    ValueTask DebounceAsync(Func<T, Task> func, T argument, int interval);
}