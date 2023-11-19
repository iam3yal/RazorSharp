namespace RazorSharp.Components.Forms;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed partial class TimePickerTests
{
    public TimePickerTests()
        => JSInterop.Mode = JSRuntimeMode.Loose;
}