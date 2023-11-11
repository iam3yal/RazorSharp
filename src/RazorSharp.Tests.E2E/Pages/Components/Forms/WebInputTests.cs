namespace RazorSharp.Pages.Components.Forms;

using System.Text.RegularExpressions;

using Microsoft.Playwright;

using RazorSharp.Tests.Kit;
using RazorSharp.Tests.Kit._Playwright;

using Xunit;

public static class WebInputTests
{
    public sealed class Focus : IClassFixture<TestServerHostFixture>
    {
        private readonly string _url;

        public Focus(TestServerHostFixture testServerHost)
            => _url = testServerHost.GetFullPageAddress("Components/Forms/WebInput/Focus");

        [Fact]
        public async Task Should_fire_OnBlur_event()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = await page.GetByTestIdAsync("WebInput");

            await input.FocusAsync();

            await input.BlurAsync();

            await Assertions.Expect(input).ToHaveAttributeAsync("data-event", new Regex("blur;"));
        }

        [Fact]
        public async Task Should_fire_OnFocus_event()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = await page.GetByTestIdAsync("WebInput");

            await input.FocusAsync();

            await Assertions.Expect(input).ToHaveAttributeAsync("data-event", new Regex("focus;"));
        }

        [Fact]
        public async Task Should_fire_OnFocusIn_event()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = await page.GetByTestIdAsync("WebInput");

            await input.FocusAsync();

            await Assertions.Expect(input).ToHaveAttributeAsync("data-event", new Regex("focusin;"));
        }

        [Fact]
        public async Task Should_fire_OnFocusOut_event()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = await page.GetByTestIdAsync("WebInput");

            await input.FocusAsync();

            await input.BlurAsync();

            await Assertions.Expect(input).ToHaveAttributeAsync("data-event", new Regex("focusout;"));
        }
    }

    public sealed class Input : IClassFixture<TestServerHostFixture>
    {
        private readonly string _url;

        public Input(TestServerHostFixture testServerHost)
            => _url = testServerHost.GetFullPageAddress("Components/Forms/WebInput/Input");

        [Fact]
        public async Task Should_fire_OnChange_event()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = await page.GetByTestIdAsync("WebInput");

            await input.FillAsync("x");

            await input.PressAsync("Enter");

            await Assertions.Expect(input).ToHaveAttributeAsync("data-event", new Regex("change;"));
        }

        [Fact]
        public async Task Should_fire_OnInput_event()
        {
            await using var playwright = await PlaywrightFactory.CreateAsync();

            var page = await playwright.Context.NewPageAsync();

            await page.NavigateToAsync(_url);

            var input = await page.GetByTestIdAsync("WebInput");

            await input.FillAsync("x");

            await Assertions.Expect(input).ToHaveAttributeAsync("data-event", new Regex("input;"));
        }
    }
}