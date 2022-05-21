namespace RazorSharp.Tests.TestDoubles.Fakes;

using RazorSharp.JSInterop.Wrappers;

public sealed class FakeHtmlElement : IHtmlElement
{
    public ValueTask BlurAsync()
        => ValueTask.CompletedTask;

    public ValueTask DisposeAsync()
        => ValueTask.CompletedTask;

    public ValueTask FocusAsync(bool preventScroll = false)
        => ValueTask.CompletedTask;
}