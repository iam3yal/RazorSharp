namespace RazorSharp.Dom;

using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

public sealed partial class CssClassBuilder
{
    private static readonly Regex InvalidChars = InvalidCharsRegex();
    private static readonly Regex PrecedingNumbersAtStart = PrecedingNumbersAtStartRegex();

    private readonly StringBuilder _classBuilder = new ();

    public bool IsEmpty
        => _classBuilder.Length == 0;

    public CssClassBuilder Append(ReadOnlySpan<char> className)
    {
        if (!className.IsEmpty)
        {
            ThrowWhenClassNameIsInvalid(className);

            _classBuilder.Append(className);
            _classBuilder.Append(' ');
        }

        return this;
    }

    public CssClassBuilder Append(CssClassBuilder? builder)
    {
        _classBuilder.Append(builder?._classBuilder);

        return this;
    }

    public CssClassBuilder AppendWhen(ReadOnlySpan<char> className, bool condition)
    {
        if (condition)
        {
            Append(className);
        }

        return this;
    }

    public void Clear()
        => _classBuilder.Clear();

    public override string ToString()
    {
        if (_classBuilder.Length > 0 && _classBuilder[^1] is ' ')
        {
            _classBuilder.Remove(_classBuilder.Length - 1, 1);
        }

        var classString = _classBuilder.ToString();

        Clear();

        return classString;
    }

    public CssClassBuilder When(bool condition, Action<CssClassBuilder> it)
    {
        if (condition)
        {
            it(this);
        }

        return this;
    }

    [GeneratedRegex("[^\\w\\s-]+")]
    private static partial Regex InvalidCharsRegex();

    [GeneratedRegex("^\\d+")]
    private static partial Regex PrecedingNumbersAtStartRegex();

    private static void ThrowWhenClassNameIsInvalid(ReadOnlySpan<char> name,
                                                    [CallerArgumentExpression("name")] string? paramName = null)
    {
        if (PrecedingNumbersAtStart.IsMatch(name))
        {
            throw new ArgumentException($"Invalid class name. The CSS class name '{paramName}' starts with a number.");
        }

        if (InvalidChars.IsMatch(name))
        {
            throw new ArgumentException(
                $"Invalid class name. The CSS class name '{paramName}' contains invalid characters.");
        }
    }
}