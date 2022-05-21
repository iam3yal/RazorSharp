namespace RazorSharp.JSInterop;

using Microsoft.JSInterop;

using RazorSharp.Core.Contracts;

public sealed class DotNetDelegateWrapper
{
    private DotNetDelegateWrapper()
    {
    }

    public object? Func { get; private set; }

    public static DotNetDelegateWrapper Create<T>(Func<T, Task> func, T argument)
        where T : class
    {
        Precondition.IsNotNull(func);

        return new ()
        {
            Func = DotNetObjectReference.Create(new FuncWrapper<T>(func, argument))
        };
    }

    private sealed class FuncWrapper<T>
        where T : class
    {
        private readonly T _argument;
        private readonly Func<T, Task> _func;

        internal FuncWrapper(Func<T, Task> func, T argument)
        {
            _func = func;
            _argument = argument;
        }

        [JSInvokable]
        public async Task InvokeAsync()
            => await _func.Invoke(_argument);
    }
}