namespace RazorSharp.Tests.TestDoubles.Testables;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

public sealed class TestableDateInput : TestableWebInput<DateTime>
{
    [Parameter]
    public string? Format { get; set; }

    protected override string FormatValue(DateTime value)
        => value.ToString(Format, Culture);

    protected override bool TryParseValue(string? value,
                                          out DateTime result,
                                          [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (DateTime.TryParse(value, out result))
        {
            validationErrorMessage = null;
            return true;
        }

        validationErrorMessage = "Bad date value";
        return false;
    }
}