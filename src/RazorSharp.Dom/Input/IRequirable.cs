namespace RazorSharp.Dom.Input;

public interface IRequirable
{
    /// <summary>
    ///     Indicates whether the user must specify a value for the input before the owning form can be submitted.
    /// </summary>
    bool Required { get; set; }
}