namespace RazorSharp.JSInterop.Wrappers;

using RazorSharp.Framework.Events;

public sealed class EventDebouncer<T> : JSModuleWrapper<EventDebouncer<T>>, IJSModuleInfo, IDebounceable<T>
    where T : class
{
    public static string FileName
        => "event-debouncer";

    public async ValueTask DebounceAsync(Func<T, Task> func, T args, int interval)
        => await Module.InvokeVoidAsync(JSWrappersConstants.Debounce,
                                        DotNetDelegateWrapper.Create(func, args),
                                        interval);
}