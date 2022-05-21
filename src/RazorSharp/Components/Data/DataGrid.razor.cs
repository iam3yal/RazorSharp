namespace RazorSharp.Components.Data;

public sealed partial class DataGrid<TItem> : WebComponent
    where TItem : class
{
    public GridCellChangeManager<TItem> CellChangeManager { get; } = new ();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public GridColumnCollection<TItem> Columns { get; } = new ();

    [Parameter]
    public ICollection<TItem>? DataSource { get; set; }

    public GridComponentRegistry Registry { get; } = new ();

    [MemberNotNullWhen(true, nameof(DataSource))]
    internal bool HasDataSource
        => DataSource is not null && DataSource.Count > 0;
}