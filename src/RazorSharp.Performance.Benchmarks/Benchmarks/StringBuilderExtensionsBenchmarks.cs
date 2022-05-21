namespace RazorSharp.Benchmarks;

using System.Diagnostics.CodeAnalysis;
using System.Text;

using BenchmarkDotNet.Attributes;

using RazorSharp.Core.Text;

[RankColumn]
[MemoryDiagnoser]
[GcServer(true)]
[SuppressMessage("ReSharper", "ReturnValueOfPureMethodIsNotUsed")]
[SuppressMessage("ReSharper", "StringIndexOfIsCultureSpecific.1")]
[SuppressMessage("ReSharper", "RedundantDefaultMemberInitializer")]
public class StringBuilderExtensionsBenchmarks
{
    [NotNull] private StringBuilder? _sb = null;

    [GlobalSetup]
    public void Setup()
    {
        _sb = new StringBuilder();
        _sb.Append("orem ipsum dolor sit amet, consectetur adipiscing elit");
        _sb.AppendLine("Nullam at neque semper, ullamcorper velit non, pharetra nisl");
        _sb.Append("Fusce nec nulla eget felis iaculis interdum");
    }

    [Benchmark]
    public void String_Contains()
        => _sb.ToString().Contains("ullamcorper");

    [Benchmark]
    public void String_IndexOf()
        => _sb.ToString().IndexOf("ullamcorper");

    [Benchmark]
    public void StringBuilder_Contains()
        => _sb.Contains("ullamcorper");

    [Benchmark]
    public void StringBuilder_IndexOf()
        => _sb.IndexOf("ullamcorper");
}