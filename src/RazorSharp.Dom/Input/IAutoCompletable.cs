namespace RazorSharp.Dom.Input;

public interface IAutoCompletable
{
    /// <summary>
    ///     Gets the value that describes what autocomplete functionality the input should provide.
    /// </summary>
    string? AutoComplete { get; set; }
}