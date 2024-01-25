namespace RazorSharp.JSInterop.Wrappers;

using System.Diagnostics.CodeAnalysis;

using RazorSharp.Framework.Events;

public sealed class EventDebouncer<T> : JSModuleWrapper<EventDebouncer<T>>, IJSModuleInfo, IDebounceable<T>
    where T : class
{
    [SuppressMessage("Design", "CA1000:Do not declare static members on generic types")]
    public static string FileName
        => "event-debouncer";

    public async ValueTask DebounceAsync(Func<T, Task> func, T arg, int interval)
        => await Module.InvokeVoidAsync(JSWrappersConstants.Debounce,
                                        DotNetDelegateWrapper.Create(func, arg),
                                        interval);
}