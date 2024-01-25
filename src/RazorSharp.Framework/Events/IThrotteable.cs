namespace RazorSharp.Framework.Events;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "NYI")]
public interface IThrotteable<T>
    where T : class
{
    ValueTask ThrottleAsync(Func<T, Task> func, T arg, int interval);
}