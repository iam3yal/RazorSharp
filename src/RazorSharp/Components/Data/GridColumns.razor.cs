namespace RazorSharp.Components.Data;

public sealed partial class GridColumns<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}