namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;
using RazorSharp.Framework.Contracts;

public sealed partial class GridRow<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public GridEditState EditState { get; set; } = GridEditState.Read;

    [Parameter]
    public TItem? Item { get; set; }

    public async ValueTask CancelEditAsync()
    {
        CascadingContext.Grid.CellChangeManager.Remove(Item);

        await ChangeEditStateAsync(GridEditState.Read);
    }

    public async ValueTask ChangeEditStateAsync(GridEditState editState)
    {
        Precondition.IsDefined(editState);

        EditState = editState;

        await InvokeAsync(StateHasChanged);
    }

    public bool Edit(GridCellDataContext<TItem>? context, object? changedValue)
        => CascadingContext.Grid.CellChangeManager.Edit(context, changedValue);

    public bool Save()
        => CascadingContext.Grid.CellChangeManager.SaveChanges(Item);

    public async ValueTask ToggleEditStateAsync(GridEditState editState)
    {
        Precondition.IsDefined(editState);

        EditState = editState switch
        {
            GridEditState.Read                        => GridEditState.Write,
            GridEditState.Write or GridEditState.None => GridEditState.Read,
            _                                         => editState
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

    protected override void OnParametersSet()
        => ParameterInvariant.IsDefined(EditState);
}