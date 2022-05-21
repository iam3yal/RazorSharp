namespace RazorSharp.JSInterop.Wrappers;

public interface IHtmlElement : IAsyncDisposable
{
    ValueTask BlurAsync();

    ValueTask FocusAsync(bool preventScroll = false);
}