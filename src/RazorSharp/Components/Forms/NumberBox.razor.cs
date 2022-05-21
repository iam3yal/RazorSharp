namespace RazorSharp.Components.Forms;

using System.Globalization;
using System.Numerics;

public partial class NumberBox<TValue> : WebInputBase<TValue>
    where TValue : INumber<TValue>
{
    public NumberBox() : base(CultureInfo.InvariantCulture)
    {
    }
}