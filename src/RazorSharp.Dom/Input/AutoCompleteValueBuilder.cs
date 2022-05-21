namespace RazorSharp.Dom.Input;

using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using RazorSharp.Core.Contracts;
using RazorSharp.Core.Runtime.CompilerServices;

public sealed class AutoCompleteValueBuilder
{
    private readonly StringBuilder _sb;

    private bool _hasOnOrOffValues;

    internal AutoCompleteValueBuilder()
        => _sb = new StringBuilder();

    public AutoCompleteValueBuilder AppendValue(AutoCompleteValue value)
    {
        Precondition.IsNotNull(value);

        if (value == AutoComplete.On || value == AutoComplete.Off)
        {
            if (_hasOnOrOffValues || _sb.Length > 0)
            {
                throw new InvalidOperationException(
                    $"The values '{AutoComplete.On}' and '{AutoComplete.Off}' are exclusive and cannot exist more than once or with other values.");
            }

            _hasOnOrOffValues = true;
        }

        return InvariantAppend($"{value}");
    }

    public override string ToString()
        => _sb.Length > 0 ? _sb.ToString(0, _sb.Length - 1) : string.Empty;

    private AutoCompleteValueBuilder InvariantAppend(
        [InterpolatedStringHandlerArgument] ref InvariantStringHandler handler)
    {
        _sb.Append(CultureInfo.InvariantCulture, $"{handler.ToString()} ");

        return this;
    }
}