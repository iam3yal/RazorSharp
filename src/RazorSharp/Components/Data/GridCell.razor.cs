namespace RazorSharp.Components.Data;

public sealed partial class GridCell<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public object? Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (CascadingContext is { Rows.OnCellCreated: { } onCellCreated, Row: { } row })
        {
            await onCellCreated(row, this);
        }
    }
}