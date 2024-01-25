namespace RazorSharp.Core.Contracts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static class Postcondition
{
    [Conditional("DEBUG")]
    public static void IsFalse(bool value,
                               [CallerArgumentExpression("value")] string? expr = null)
    {
        if (value)
        {
            throw new AssertException($"The value of '{expr}' is true.");
        }
    }

    [Conditional("DEBUG")]
    public static void IsNotEmpty([NotNull] string? value,
                                  [CallerArgumentExpression("value")] string? expr = null)
    {
        IsNotNull(value, expr);

        if (value.Length is 0)
        {
            throw new AssertException($"The value of '{expr}' cannot be empty.");
        }
    }

    [Conditional("DEBUG")]
    public static void IsNotNull<T>([NotNull] T? value,
                                    [CallerArgumentExpression("value")] string? expr = null)
    {
        if (value is null)
        {
            throw new AssertException($"The value of '{expr}' cannot be null.");
        }
    }

    [Conditional("DEBUG")]
    public static void IsTrue(bool value,
                              [CallerArgumentExpression("value")] string? expr = null)
    {
        if (!value)
        {
            throw new AssertException($"The value of '{expr}' is false.");
        }
    }

    public sealed class AssertException(string? message) : Exception(message);
}