namespace RazorSharp.Components.DataGrid;

using System.Diagnostics.CodeAnalysis;

using RazorSharp.Components.Data;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed partial class GridSaveButtonTests
{
    private GridSaveButtonEventArgs? _args;

    public GridSaveButtonTests()
        => JSInterop.Mode = JSRuntimeMode.Loose;

    [SuppressMessage("ReSharper", "SeparateLocalFunctionsWithJumpStatement")]
    private async ValueTask OnSaveHandlerAsync(GridSaveButtonEventArgs e)
    {
        _args = e;

        await ValueTask.CompletedTask;
    }
}