namespace RazorSharp.Core;

public interface IValueDefaultable<out T>
{
    static abstract T Default { get; }
}