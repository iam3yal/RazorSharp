namespace RazorSharp.Dom.Input;

using System.Numerics;

public interface IRangeable<T> : IAutoCompletable, ISteppable<T>, IDataListable
    where T : INumber<T>
{
}