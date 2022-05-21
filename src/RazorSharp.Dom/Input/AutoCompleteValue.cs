namespace RazorSharp.Dom.Input;

using RazorSharp.Core;
using RazorSharp.Core.Strings;

public sealed record AutoCompleteValue : TypedString<AutoCompleteValue>, IValueDefaultable<AutoCompleteValue>
{
    internal AutoCompleteValue(string value) : base(value)
    {
    }

    public static AutoCompleteValue Default
        => AutoComplete.Off;
}