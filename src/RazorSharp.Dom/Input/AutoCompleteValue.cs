namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

using RazorSharp.Core;
using RazorSharp.Core.Strings;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed record AutoCompleteValue : TypedString<AutoCompleteValue>, IValueDefaultable<AutoCompleteValue>
{
    internal AutoCompleteValue(string value) : base(value)
    {
    }

    public static AutoCompleteValue Default
        => AutoComplete.Off;
}