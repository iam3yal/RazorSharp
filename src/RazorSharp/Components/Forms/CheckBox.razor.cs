namespace RazorSharp.Components.Forms;

using System.Globalization;

public partial class CheckBox : WebInputBase<bool>
{
    public CheckBox() : base(CultureInfo.InvariantCulture)
    {
    }
}