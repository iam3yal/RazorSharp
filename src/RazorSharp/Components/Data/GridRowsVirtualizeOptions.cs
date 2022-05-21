namespace RazorSharp.Components.Data;

using Microsoft.AspNetCore.Components.Web.Virtualization;

public sealed class GridRowsVirtualizeOptions<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? EmptyContent { get; set; }

    [Parameter]
    public float ItemSize { get; set; } = 50f;

    [Parameter]
    public int OverscanCount { get; set; } = 3;

    [Parameter]
    public RenderFragment<PlaceholderContext>? Placeholder { get; set; }

    [Parameter]
    public string SpacerElement { get; set; } = "div";

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!CascadingContext.IsInsideOf(GridSection.Options))
        {
            throw new InvalidOperationException(
                $"The component '{nameof(GridRowsVirtualizeOptions<TItem>)}' can only exist inside '{nameof(GridComponentRegistry)}'.");
        }

        CascadingContext.Grid.Registry.Add<GridRowsVirtualizeOptions<TItem>>(this);
    }
}