namespace RazorSharp.Components.Data;

public abstract class GridComponentBase<TItem> : WebComponent
    where TItem : class
{
    protected GridCascadingContext<TItem> CascadingContext
        => new (Grid,
                Options,
                Column,
                Columns,
                Row,
                Rows,
                Cell);

    [CascadingParameter(Name = "Cell")]
    private GridCell<TItem>? Cell { get; set; }

    [CascadingParameter(Name = "Column")]
    private GridColumn<TItem>? Column { get; set; }

    [CascadingParameter(Name = "Columns")]
    private GridColumns<TItem>? Columns { get; set; }

    [CascadingParameter(Name = "RazorGrid")]
    private DataGrid<TItem>? Grid { get; set; }

    [CascadingParameter(Name = "Options")]
    private GridOptions<TItem>? Options { get; set; }

    [CascadingParameter(Name = "Row")]
    private GridRow<TItem>? Row { get; set; }

    [CascadingParameter(Name = "Rows")]
    private GridRows<TItem>? Rows { get; set; }
}