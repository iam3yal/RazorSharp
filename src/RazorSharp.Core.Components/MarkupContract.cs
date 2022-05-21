namespace RazorSharp.Core.Components;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Components;

using RazorSharp.Core.Contracts;

public static class MarkupContract
{
    public static MarkupString IsNotEmpty<T>(ReadOnlySpan<T> value,
                                             [CallerArgumentExpression("value")] string paramName = "")
    {
        Precondition.IsNotEmpty(value, paramName);

        return Markup.Empty;
    }

    public static MarkupString IsNotNull<T>([NotNull] T? value,
                                            [CallerArgumentExpression("value")] string paramName = "")
    {
        Precondition.IsNotNull(value, paramName);

        return Markup.Empty;
    }
}