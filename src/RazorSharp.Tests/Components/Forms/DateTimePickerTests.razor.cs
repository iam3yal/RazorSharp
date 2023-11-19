namespace RazorSharp.Components.Forms;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed partial class DateTimePickerTests
{
    public DateTimePickerTests()
        => JSInterop.Mode = JSRuntimeMode.Loose;
}