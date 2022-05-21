namespace RazorSharp.Core.Contracts;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public static class Precondition
{
    private const string CannotBeEmptyMessage = "Value cannot be empty.";
    private const string NotWithinRangeMessage = "Specified argument was out of the range of valid values.";

    public static void IsInRange(bool condition,
                                 [CallerArgumentExpression("condition")] string paramExp = "")
    {
        if (!condition)
        {
            throw new ArgumentOutOfRangeException($"{NotWithinRangeMessage} (Condition '{paramExp}')");
        }
    }

    public static void IsNotEmpty([NotNull] string? value,
                                  [CallerArgumentExpression("value")] string paramName = "")
    {
        IsNotNull(value);

        if (value.Length is 0)
        {
            throw new ArgumentException(CannotBeEmptyMessage, paramName);
        }
    }

    public static void IsNotEmpty<T>(ReadOnlySpan<T> value,
                                     [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value.IsEmpty)
        {
            throw new ArgumentException(CannotBeEmptyMessage, paramName);
        }
    }

    public static void IsNotNull<T>([NotNull] T? value,
                                    [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}