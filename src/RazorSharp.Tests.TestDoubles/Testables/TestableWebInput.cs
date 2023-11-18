namespace RazorSharp.Tests.TestDoubles.Testables;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using RazorSharp.Components.Forms;
using RazorSharp.Framework.Events;
using RazorSharp.JSInterop.Wrappers;
using RazorSharp.Tests.TestDoubles.Fakes;

[SuppressMessage("ReSharper", "StaticMemberInGenericType")]
public class TestableWebInput<TValue> : WebInputBase<TValue>
{
    private static readonly IDebounceable<ChangeEventArgs> FakeDebouncer = new FakeDebouncer<ChangeEventArgs>();
    private static readonly IHtmlElement FakeInput = new FakeHtmlElement();

    public TestableWebInput() : base(CultureInfo.InvariantCulture)
    {
    }

    public new EditContext? EditContext
        => base.EditContext;

    public new FieldIdentifier FieldIdentifier
        => base.FieldIdentifier;

    public new string? MergedClass
        => base.MergedClass;

    public int ValidationStateChangedCounter { get; private set; }

    protected override IHtmlElement Input
        => FakeInput;

    protected override IDebounceable<ChangeEventArgs> InputEventDebouncer
        => FakeDebouncer;

    protected override void OnValidationStateChanged()
        => ValidationStateChangedCounter++;
}