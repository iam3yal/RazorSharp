namespace RazorSharp.Dom.Input;

using System.Numerics;

public interface INumberInput<T> : IFormInput<T>, ITypable, IRangeable<T>
    where T : INumber<T>
{
}