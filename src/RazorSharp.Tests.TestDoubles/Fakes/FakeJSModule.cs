namespace RazorSharp.Tests.TestDoubles.Fakes;

using System.Diagnostics.CodeAnalysis;

using RazorSharp.JSInterop;
using RazorSharp.JSInterop.Wrappers;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Local")]
public sealed class FakeJSModule : JSModuleWrapper<FakeJSModule>, IJSModuleInfo
{
    public static string FileName
        => "jsModuleFake";
}