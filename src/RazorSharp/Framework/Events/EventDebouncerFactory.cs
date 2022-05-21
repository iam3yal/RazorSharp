namespace RazorSharp.Framework.Events;

using RazorSharp.Core.Runtime;
using RazorSharp.JSInterop;

public static class EventDebouncerFactory
{
    public static async ValueTask<IDebounceable<T>> Create<T>(IJSRuntime runtime,
                                                              ElementReference element)
        where T : class
    {
        if (RuntimeHost.IsClientSide)
        {
            return new EventDebouncer<T>();
        }

        if (RuntimeHost.IsServerSide)
        {
            return await runtime.CreateInstanceAsyncAs<JSInterop.Wrappers.EventDebouncer<T>>(element);
        }

        throw new InvalidOperationException("RuntimeHost is not supported.");
    }
}