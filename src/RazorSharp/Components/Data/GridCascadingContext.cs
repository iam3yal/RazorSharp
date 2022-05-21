namespace RazorSharp.Components.Data;

using RazorSharp.Core.Contracts;

public readonly ref struct GridCascadingContext<TItem>
    where TItem : class
{
    public GridCascadingContext(DataGrid<TItem>? grid,
                                GridOptions<TItem>? options,
                                GridColumn<TItem>? column,
                                GridColumns<TItem>? columns,
                                GridRow<TItem>? row,
                                GridRows<TItem>? rows,
                                GridCell<TItem>? cell)
    {
        Precondition.IsNotNull(grid);

        Grid = grid;
        Options = options;
        Column = column;
        Columns = columns;
        Row = row;
        Rows = rows;
        Cell = cell;
    }

    public GridColumn<TItem>? Column { get; }

    public DataGrid<TItem> Grid { get; }

    public GridRow<TItem>? Row { get; }

    public GridCell<TItem>? Cell { get; }

    private GridColumns<TItem>? Columns { get; }

    private GridOptions<TItem>? Options { get; }

    private GridRows<TItem>? Rows { get; }

    public bool IsInsideOf(GridSection insideOf)
    {
        var checkedFlags = GridSection.None;

        if ((insideOf & GridSection.Grid) is not 0 && Grid is not null)
        {
            checkedFlags |= GridSection.Grid;
        }

        if ((insideOf & GridSection.Options) is not 0 && Options is not null)
        {
            checkedFlags |= GridSection.Options;
        }

        if ((insideOf & GridSection.Column) is not 0 && Column is not null)
        {
            checkedFlags |= GridSection.Column;
        }

        if ((insideOf & GridSection.Columns) is not 0 && Columns is not null)
        {
            checkedFlags |= GridSection.Columns;
        }

        if ((insideOf & GridSection.Row) is not 0 && Row is not null)
        {
            checkedFlags |= GridSection.Row;
        }

        if ((insideOf & GridSection.Rows) is not 0 && Rows is not null)
        {
            checkedFlags |= GridSection.Rows;
        }

        if ((insideOf & GridSection.Cell) is not 0 && Cell is not null)
        {
            checkedFlags |= GridSection.Cell;
        }

        return insideOf == checkedFlags;
    }
}