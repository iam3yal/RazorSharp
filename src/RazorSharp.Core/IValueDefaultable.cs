namespace RazorSharp.Core;

using System.Diagnostics.CodeAnalysis;

public interface IValueDefaultable<out T>
{
    [SuppressMessage("Design", "CA1000:Do not declare static members on generic types",
                     Justification = "Factory property")]
    static abstract T Default { get; }
}