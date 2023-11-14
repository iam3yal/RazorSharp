namespace RazorSharp.Components.Data;

using System.ComponentModel;

public sealed partial class GridRow<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public GridEditState EditState { get; private set; } = GridEditState.Read;

    [Parameter]
    public TItem? Item { get; set; }

    public async ValueTask CancelEditAsync()
    {
        CascadingContext.Grid.CellChangeManager.RemoveRow(this);

        await ChangeEditStateAsync(GridEditState.Read);
    }

    public async ValueTask ChangeEditStateAsync(GridEditState editState)
    {
        EditState = editState switch
        {
            GridEditState.Read => GridEditState.Read,
            GridEditState.Write => GridEditState.Write,
            GridEditState.None => GridEditState.None,
            _ => throw new InvalidEnumArgumentException(nameof(editState), (int) editState, typeof(GridEditState))
        };

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
            GridEditState.Read => GridEditState.Write,
            GridEditState.Write or GridEditState.None => GridEditState.Read,
            _ => throw new InvalidEnumArgumentException(nameof(editState), (int) editState, typeof(GridEditState))
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