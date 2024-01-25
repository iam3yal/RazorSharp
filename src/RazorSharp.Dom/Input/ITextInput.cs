namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface ITextInput : IFormInput<string>, ITypable, IDataListable, IPatternable
{
    /// <summary>
    ///     Determines the maximum number of characters (as UTF-16 code units) the user can enter into the field. This must be a positive integer value greater than or equal to the value specified by <see cref="MinLength" />. If no <c>MaxLength</c> is specified, or an invalid value is specified, the field has no maximum length.
    /// </summary>
    int MaxLength { get; set; }

    /// <summary>
    ///     Determines the minimum number of characters (as UTF-16 code units) the user can enter into the entry field. This must be a positive integer value between zero and the value specified by <see cref="MaxLength" />. If no <c>MinLength</c> is specified, or an invalid value is specified, the input has no minimum length.
    /// </summary>
    int MinLength { get; set; }
}