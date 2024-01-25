namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface INumberInput<T> : IFormInput<T>, ITypable, IRangeable<T>
    where T : INumber<T>;