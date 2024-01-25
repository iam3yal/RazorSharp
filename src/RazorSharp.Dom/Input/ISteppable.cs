namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface ISteppable<T>
    where T : INumber<T>
{
    /// <summary>
    ///     Determines the greatest value in the range of permitted values.
    /// </summary>
    T Max { get; set; }

    /// <summary>
    ///     Determines the most negative value in the range of permitted values.
    /// </summary>
    T Min { get; set; }

    /// <summary>
    ///     Specifies the stepping interval.
    /// </summary>
    T Step { get; set; }
}