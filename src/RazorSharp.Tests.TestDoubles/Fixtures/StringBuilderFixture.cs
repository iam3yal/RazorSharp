namespace RazorSharp.Tests.TestDoubles.Fixtures;

using System.Text;

public sealed class StringBuilderFixture
{
    public StringBuilder StringBuilder { get; } = new ();

    public void AppendChunkedLoremIpsumText()
    {
        StringBuilder.Clear();

        StringBuilder.Append("orem ipsum dolor sit amet, consec");
        StringBuilder.Append("tetur adipiscing elit");
    }

    public void AppendLoremIpsumText()
    {
        StringBuilder.Clear();

        StringBuilder.Append("orem ipsum dolor sit amet, consectetur adipiscing elit");
        StringBuilder.AppendLine("Nullam at neque semper, ullamcorper velit non, pharetra nisl");
        StringBuilder.Append("Fusce nec nulla eget felis iaculis interdum");
    }
}