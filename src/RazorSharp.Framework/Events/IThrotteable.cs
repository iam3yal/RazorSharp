namespace RazorSharp.Framework.Events;

public interface IThrotteable<T>
    where T : class
{
    ValueTask ThrottleAsync(Func<T, Task> func, T argument, int interval);
}