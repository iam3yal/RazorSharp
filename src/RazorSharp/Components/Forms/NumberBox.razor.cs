namespace RazorSharp.Components.Forms;

using System.Globalization;
using System.Numerics;

public partial class NumberBox<TValue>() : WebInputBase<TValue>(CultureInfo.InvariantCulture)
    where TValue : INumber<TValue>
{
}