namespace RazorSharp.Framework.Contracts;

using System.Runtime.CompilerServices;

public static class ParameterInvariant
{
    private const string CannotBeEmptyMessage = "Value cannot be empty.";
    private const string CannotBeNull = "Value cannot be null.";

    public static void IsDefined<TEnum>(TEnum value,
                                        [CallerArgumentExpression("value")] string paramName = "")
        where TEnum : Enum
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
        {
            throw new InvalidParameterException(paramName,
                                                $"Please use the defined values in the enum '{typeof(TEnum)}'.");
        }
    }

    public static void IsNotEmpty([NotNull] string? value,
                                  [CallerArgumentExpression("value")] string paramName = "")
    {
        IsNotNull(value);

        if (value.Length is 0)
        {
            throw new InvalidParameterException(paramName, CannotBeEmptyMessage);
        }
    }

    public static void IsNotNull<T>([NotNull] T? value,
                                    [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value is null)
        {
            throw new InvalidParameterException(paramName, CannotBeNull);
        }
    }
}