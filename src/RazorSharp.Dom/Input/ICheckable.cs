namespace RazorSharp.Dom.Input;

public interface ICheckable
{
    /// <summary>
    ///     Determines whether the input is checked.
    /// </summary>
    bool IsChecked { get; set; }
}