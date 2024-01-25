namespace RazorSharp.Components.Data;

using Microsoft.AspNetCore.Components.Web.Virtualization;

using RazorSharp.Framework.Components.Data;

public sealed partial class DataGrid<TItem> : WebComponent
    where TItem : class
{
    public CellChangeManager<TItem> CellChangeManager { get; } = new ();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public GridColumnCollection<TItem> Columns { get; } = new ();

    [Parameter]
    public IEnumerable<TItem>? Items { get; set; }

    [Parameter]
    public ItemsProviderDelegate<TItem>? ItemsProvider { get; set; }

    public Func<ValueTask>? OnRefresh { get; set; }

    public GridComponentRegistry Registry { get; } = new ();

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public async ValueTask RefreshAsync()
    {
        if (OnRefresh is not null)
        {
            await OnRefresh();
            await InvokeAsync(StateHasChanged);
        }
    }

    protected override void OnParametersSet()
    {
        if (Items is not null && ItemsProvider is not null)
        {
            throw new InvalidOperationException(
                $"The '{nameof(DataGrid<TItem>)}' can only accept a single source of data.\nDo not supply both '{nameof(Items)}' and '{nameof(ItemsProvider)}'.");
        }
    }
}