namespace RazorSharp.Components.Forms;

using System.Globalization;

public sealed class WebInput<TValue> : WebInputBase<TValue>
{
    public WebInput() : base(CultureInfo.CurrentCulture)
    {
    }
}