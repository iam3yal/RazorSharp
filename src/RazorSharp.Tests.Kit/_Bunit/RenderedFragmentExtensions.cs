namespace RazorSharp.Tests.Kit._Bunit;

using System.Diagnostics.CodeAnalysis;

using AngleSharp.Dom;

using Bunit;

using RazorSharp.Core.Contracts;

public static class RenderedFragmentExtensions
{
    public static bool TryFind(this IRenderedFragment renderedFragment,
                               string cssSelector,
                               [MaybeNullWhen(false)] out IElement element)
    {
        Precondition.IsNotNull(renderedFragment);

        if (renderedFragment.Nodes.QuerySelector(cssSelector) is { } result)
        {
            element = result;

            return true;
        }

        element = null;

        return false;
    }
}