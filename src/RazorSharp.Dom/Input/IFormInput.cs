namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IFormInput<TValue>
{
    /// <summary>
    ///     Specifies the <c>Form</c> component located in the same document as the input's owner.
    /// </summary>
    object? Form { get; set; }

    /// <summary>
    ///     Determines whether the user can interact with the input.
    /// </summary>
    bool IsDisabled { get; set; }

    /// <summary>
    ///     Specifies the <c>Name</c> of the input.
    /// </summary>
    string? Name { get; set; }

    /// <summary>
    ///     Provides text representing advisory information related to the input. Such information can typically, but not necessarily, be presented to the user as a tooltip.
    /// </summary>
    string? Title { get; set; }

    /// <summary>
    ///     Gets the type of input to render.
    /// </summary>
    InputType Type { get; }

    /// <summary>
    ///     Specifies the <c>Value</c> of the input. When specified this is the initial value of the input.
    /// </summary>
    TValue? Value { get; set; }
}