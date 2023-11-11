namespace RazorSharp.Components.Data;

public sealed partial class GridRow<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public GridEditState EditState { get; private set; } = GridEditState.Read;

    public async ValueTask CancelEditAsync()
    {
        CascadingContext.Grid.CellChangeManager.RemoveRow(this);

        await ChangeEditStateAsync(GridEditState.Read);
    }

    public async ValueTask ChangeEditStateAsync(GridEditState editState)
    {
        EditState = editState;

        await InvokeAsync(StateHasChanged);
    }

    public bool Edit(GridCellDataContext<TItem>? context, object? changedValue)
        => CascadingContext.Grid.CellChangeManager.EditRowCell(this, context, changedValue);

    public bool Save()
        => CascadingContext.Grid.CellChangeManager.SaveRowChanges(this);

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

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (CascadingContext is { Rows.OnRowCreated: { } onRowCreated })
        {
            await onRowCreated(this);
        }
    }
}