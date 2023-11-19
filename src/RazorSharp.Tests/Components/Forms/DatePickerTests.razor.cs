namespace RazorSharp.Components.Forms;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed partial class DatePickerTests
{
    public DatePickerTests()
        => JSInterop.Mode = JSRuntimeMode.Loose;
}