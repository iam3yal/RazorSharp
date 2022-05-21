namespace RazorSharp.Components.Data;

public sealed partial class GridColumn<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    [Parameter]
    public RenderFragment? ActionTemplate { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public int Index { get; private set; } = -1;

    internal GridColumnActionCollection<TItem>? Actions { get; private set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!CascadingContext.IsInsideOf(GridSection.Columns))
        {
            throw new InvalidOperationException(
                $"The component '{nameof(GridColumn<TItem>)}' can only exist inside '{nameof(GridColumns<TItem>)}'.");
        }

        if (ActionTemplate is not null)
        {
            Actions = new ();
        }

        Index = CascadingContext.Grid.Columns.Add(this);
    }
}