namespace RazorSharp.Components.DataGrid;

using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Components;

using RazorSharp.Components.Data;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public sealed partial class GridSaveButtonTests : ComponentBase, IDisposable
{
    private readonly TestContext _ctx = new ();

    private GridSaveButtonEventArgs? _args;

    public GridSaveButtonTests()
        => _ctx.JSInterop.Mode = JSRuntimeMode.Loose;

    public void Dispose()
        => _ctx.Dispose();

    [SuppressMessage("ReSharper", "SeparateLocalFunctionsWithJumpStatement")]
    private async ValueTask OnSaveHandlerAsync(GridSaveButtonEventArgs e)
    {
        _args = e;

        await ValueTask.CompletedTask;
    }
}