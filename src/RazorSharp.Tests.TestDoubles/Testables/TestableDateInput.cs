namespace RazorSharp.Tests.TestDoubles.Testables;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

// REF: https://github.com/dotnet/aspnetcore/blob/v7.0.9/src/Components/Web/test/Forms/InputBaseTest.cs#L551
public sealed class TestableDateInput : TestableWebInput<DateTime>
{
    protected override string FormatValue(DateTime value)
        => value.ToString(Format, Culture);

    [Parameter]
    public string? Format { get; set; }

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