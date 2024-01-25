namespace RazorSharp.Components.Forms;

using System.Globalization;

public sealed class WebInput<TValue>() : WebInputBase<TValue>(CultureInfo.CurrentCulture);