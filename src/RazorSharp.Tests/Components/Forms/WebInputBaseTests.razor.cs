namespace RazorSharp.Components.Forms;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed partial class WebInputBaseTests
{
    public WebInputBaseTests()
        => JSInterop.Mode = JSRuntimeMode.Loose;
}