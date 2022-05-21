namespace RazorSharp.Tests.TestDoubles.Fakes;

// REF: https://github.com/dotnet/aspnetcore/blob/v7.0.9/src/Components/Web/test/Forms/InputBaseTest.cs#L506
public sealed class FakeModel
{
    public DateTime DateProperty { get; set; }

    public string StringProperty { get; set; } = "";
}