namespace RazorSharp.Components.Data;

public sealed class GridSaveButtonEventArgs : EventArgs
{
    public GridSaveButtonEventArgs(bool isSaved)
        => IsSaved = isSaved;

    public bool IsSaved { get; }

    public GridEditState RowEditState { get; internal set; } = GridEditState.None;
}