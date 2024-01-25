namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IRequirable
{
    /// <summary>
    ///     Indicates whether the user must specify a value for the input before the owning form can be submitted.
    /// </summary>
    bool Required { get; set; }
}