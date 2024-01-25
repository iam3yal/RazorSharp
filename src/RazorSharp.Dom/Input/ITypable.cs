namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface ITypable : IAutoCompletable, IRequirable
{
    /// <summary>
    ///     Enables the submission of the directionality of the element. When included, the form control will submit with two name/value pairs: the first being the <see cref="IFormInput{TValue}.Name" /> and <see cref="IFormInput{TValue}.Value" /> , the second being the value of the <c>DirectionName</c> as the name with the value of ltr or rtl being set by the browser.
    /// </summary>
    string? DirectionName { get; set; }

    /// <summary>
    ///     Specifies the height of the input.
    /// </summary>
    int Height { get; set; }

    /// <summary>
    ///     Indicates that the user should not be able to edit the value of the input.
    /// </summary>
    bool IsReadOnly { get; set; }

    /// <summary>
    ///     Provides a brief hint to the user as to what kind of information is expected in the field. It should be a word or short phrase that provides a hint as to the expected type of data, rather than an explanation or prompt.
    /// </summary>
    string? Placeholder { get; set; }

    /// <summary>
    ///     Specifies the width of the input.
    /// </summary>
    int Width { get; set; }
}