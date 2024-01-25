namespace RazorSharp.Dom.Input;

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IRangeable<T> : IAutoCompletable, ISteppable<T>, IDataListable
    where T : INumber<T>;