namespace RazorSharp.Components.Data;

using Microsoft.AspNetCore.Components.Rendering;

public sealed class GridOptions<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        builder.OpenComponent<CascadingValue<GridOptions<TItem>>>(0);
        builder.AddAttribute(1, "Name", "Options");
        builder.AddAttribute(2, "Value", this);
        builder.AddAttribute(3, "IsFixed", true);
        builder.AddAttribute(4, "ChildContent", (RenderFragment) (b => {
            b.AddContent(4, ChildContent);
        }));
        builder.CloseComponent();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!CascadingContext.IsInsideOf(GridSection.Grid))
        {
            throw new InvalidOperationException(
                $"The component '{nameof(GridOptions<TItem>)}' can only exist inside '{nameof(DataGrid<TItem>)}'.");
        }
    }
}