namespace RazorSharp.Tests.Kit._Playwright;

using Microsoft.Playwright;

public static class PlaywrightFactory
{
    public static async Task<PlaywrightWrapper> CreateAsync(BrowserTypeLaunchOptions? options = null)
    {
        var playwright = await Playwright.CreateAsync();

        var browser = await playwright.Chromium.LaunchAsync(options
                                                            ?? new BrowserTypeLaunchOptions
                                                            {
                                                                Headless = true
                                                            });

        var context = await browser.NewContextAsync(new BrowserNewContextOptions()
        {
            IgnoreHTTPSErrors = true
        });

        return new PlaywrightWrapper(playwright, browser, context);
    }

    public sealed class PlaywrightWrapper : IAsyncDisposable
    {
        public PlaywrightWrapper(IPlaywright playwright, IBrowser browser, IBrowserContext context)
        {
            Playwright = playwright;
            Browser = browser;
            Context = context;
        }

        public IBrowser Browser { get; }

        public IBrowserContext Context { get; }

        public IPlaywright Playwright { get; }

        public void Deconstruct(out IBrowser browser,
                                out IBrowserContext context)
        {
            browser = Browser;
            context = Context;
        }

        public async ValueTask DisposeAsync()
        {
            await Context.DisposeAsync();

            await Browser.DisposeAsync();

            Playwright.Dispose();
        }
    }
}