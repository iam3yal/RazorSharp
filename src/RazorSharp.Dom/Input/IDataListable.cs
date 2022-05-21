namespace RazorSharp.Dom.Input;

public interface IDataListable
{
    /// <summary>
    ///     Specifies the <c>DataList</c> component located in the same document to provide a list of predefined values for the input.
    /// </summary>
    object? DataList { get; set; }
}