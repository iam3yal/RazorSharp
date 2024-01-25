namespace RazorSharp.Components.Data;

public sealed class GridSaveButtonEventArgs(bool isSaved) : EventArgs
{
    public bool IsSaved { get; } = isSaved;

    public GridEditState RowEditState { get; internal set; } = GridEditState.None;
}