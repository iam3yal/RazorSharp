namespace RazorSharp.JSInterop;

public static class JSInteropPathTests
{
    public static class CreatePath
    {
        [Fact]
        public static void Should_return_fullpath_of_embedded_module()
        {
            const string embeddedPath = "./_content/RazorSharp.Components/MyFilename.mjs";

            var createdPath = JSInteropPath.CreatePath("MyFilename");

            Assert.Equal(embeddedPath, createdPath);
        }
    }
}