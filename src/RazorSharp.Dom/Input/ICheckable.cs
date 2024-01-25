namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface ICheckable
{
    /// <summary>
    ///     Determines whether the input is checked.
    /// </summary>
    bool IsChecked { get; set; }
}