namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IPatternable
{
    /// <summary>
    ///     Specifies the regular expression for the input's <see cref="IFormInput{TValue}.Value" />. It must be a valid JavaScript regular expression.
    /// </summary>
    string? Pattern { get; set; }
}