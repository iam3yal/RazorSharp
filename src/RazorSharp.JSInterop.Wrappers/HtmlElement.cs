namespace RazorSharp.JSInterop.Wrappers;

using Microsoft.AspNetCore.Components;

public sealed class HtmlElement : JSModuleWrapper<HtmlElement>, IJSModuleInfo, IHtmlElement
{
    public static string FileName
        => "html-element";

    public async ValueTask BlurAsync()
        => await Module.InvokeVoidAsync(JSWrappersConstants.Blur, Element);

    public async ValueTask FocusAsync(bool preventScroll = false)
        => await Element.FocusAsync(preventScroll);
}