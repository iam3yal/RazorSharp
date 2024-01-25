namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IAutoCompletable
{
    /// <summary>
    ///     Gets the value that describes what autocomplete functionality the input should provide.
    /// </summary>
    string? AutoComplete { get; set; }
}