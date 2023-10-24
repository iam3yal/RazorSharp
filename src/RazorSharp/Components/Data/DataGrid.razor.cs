namespace RazorSharp.Components.Data;

using Microsoft.AspNetCore.Components.Web.Virtualization;

public sealed partial class DataGrid<TItem> : WebComponent
    where TItem : class
{
    public GridCellChangeManager<TItem> CellChangeManager { get; } = new ();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public GridColumnCollection<TItem> Columns { get; } = new ();

    [Parameter]
    public ICollection<TItem>? Items { get; set; }

    [Parameter]
    public ItemsProviderDelegate<TItem>? ItemsProvider { get; set; }

    public GridComponentRegistry Registry { get; } = new ();

    protected override void OnParametersSet()
    {
        if (Items is not null && ItemsProvider is not null)
        {
            throw new InvalidOperationException(
                $"The '{nameof(DataGrid<TItem>)}' can only accept a single source of data.\nDo not supply both '{nameof(Items)}' and '{nameof(ItemsProvider)}'.");
        }
    }
}