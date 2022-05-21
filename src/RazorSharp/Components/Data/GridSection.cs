namespace RazorSharp.Components.Data;

[Flags]
public enum GridSection
{
    None = 0,
    Grid = 1 << 0,
    Options = 1 << 1,
    Column = 1 << 2,
    Columns = 1 << 3,
    Row = 1 << 4,
    Rows = 1 << 5,
    Cell = 1 << 6
}