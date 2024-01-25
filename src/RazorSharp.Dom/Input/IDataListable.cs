namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IDataListable
{
    /// <summary>
    ///     Specifies the <c>DataList</c> component located in the same document to provide a list of predefined values for the input.
    /// </summary>
    object? DataList { get; set; }
}