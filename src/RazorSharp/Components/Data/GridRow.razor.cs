namespace RazorSharp.Components.Data;

public sealed partial class GridRow<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public GridEditState EditState { get; private set; } = GridEditState.Read;

    public async ValueTask ChangeEditStateAsync(GridEditState editState)
    {
        EditState = editState;

        await InvokeAsync(StateHasChanged);
    }

    public async ValueTask ToggleEditStateAsync(GridEditState editState)
    {
        EditState = editState switch
        {
            GridEditState.Read  => GridEditState.Write,
            GridEditState.Write => GridEditState.Read,
            _                   => GridEditState.None
        };

        await InvokeAsync(StateHasChanged);
    }
}