namespace RazorSharp.Pages.Interop;

using Microsoft.Playwright;

using RazorSharp.Tests.Kit;
using RazorSharp.Tests.Kit._Playwright;

using Xunit;

public static class HtmlElementTests
{
    public sealed class Focus : IClassFixture<TestServerHostFixture>
    {
        private readonly string _url;

        public Focus(TestServerHostFixture testServerHost)
            => _url = testServerHost.GetFullPageAddress("Interop/HtmlElement/Focus");

        [Fact]
        public async Task Should_remove_focus()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = page.GetByTestId("Input");

            await page.GetByTestId("Focus").ClickAsync();

            await page.GetByTestId("Blur").ClickAsync();

            await Assertions.Expect(input).Not.ToBeFocusedAsync();
        }

        [Fact]
        public async Task Should_set_focus()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = page.GetByTestId("Input");

            await page.GetByTestId("Focus").ClickAsync();

            await Assertions.Expect(input).ToBeFocusedAsync();
        }
    }
}