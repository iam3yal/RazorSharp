namespace RazorSharp.Tests.TestDoubles.Fakes;

using Microsoft.AspNetCore.Components;

public static class FakeElementReferenceFactory
{
    public static ElementReference Create()
        => new ("FAKE");
}