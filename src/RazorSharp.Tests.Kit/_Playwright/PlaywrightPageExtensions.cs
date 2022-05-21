namespace RazorSharp.Tests.Kit._Playwright;

using Microsoft.Playwright;

using RazorSharp.Core.Contracts;

public static class PlaywrightPageExtensions
{
    public static async Task<ILocator> GetByTestIdAsync(this IPage page, string testId)
    {
        Precondition.IsNotNull(page);
        Precondition.IsNotEmpty(testId);

        var locator = page.GetByTestId(testId);

        // NOTE: Waits for the element to be visible.
        await locator.WaitForAsync();

        return locator;
    }

    public static async Task NavigateToAsync(this IPage page, string url)
    {
        Precondition.IsNotNull(page);
        Precondition.IsNotEmpty(url);

        // NOTE: Playwright discourages using LoadState.NetworkIdle for testing
        // but when dealing with Blazor waiting for the LoadState.Load isn't sufficient
        // because we have to wait for Blazor rendering lifecycle to end completely before we can do anything.
        await page.GotoAsync(url,
                             new PageGotoOptions()
                             {
                                 WaitUntil = WaitUntilState.NetworkIdle
                             });
    }
}