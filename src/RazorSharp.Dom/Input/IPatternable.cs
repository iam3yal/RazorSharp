namespace RazorSharp.Dom.Input;

public interface IPatternable
{
    /// <summary>
    ///     Specifies the regular expression for the input's <see cref="IFormInput{TValue}.Value" />. It must be a valid JavaScript regular expression.
    /// </summary>
    string? Pattern { get; set; }
}