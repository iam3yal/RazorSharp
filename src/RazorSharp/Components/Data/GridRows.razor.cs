namespace RazorSharp.Components.Data;

public sealed partial class GridRows<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    private bool _rerendered = false;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RenderFragment<GridRowTemplateContext<TItem>>? RowTemplate { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _rerendered = true;

            await InvokeAsync(StateHasChanged);
        }
    }
}