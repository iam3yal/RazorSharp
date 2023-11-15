namespace RazorSharp.Components.Data;

using Microsoft.AspNetCore.Components.Web;

using RazorSharp.Core.Contracts;
using RazorSharp.Framework.Contracts;

public abstract partial class GridActionButton<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    private bool _isTemplate;

    protected GridActionButton(string name, GridEditState editState)
    {
        Precondition.IsNotEmpty(name);
        Precondition.IsDefined(editState);

        Name = name;
        EditState = editState;
    }

    public GridEditState EditState { get; private set; }

    [Parameter]
    public string? Name { get; set; }

    internal Dictionary<string, object?>? Parameters { get; private set; }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);

        if (_isTemplate)
        {
            foreach (var parameter in parameters)
            {
                if (!parameter.Cascading)
                {
                    Parameters ??= new Dictionary<string, object?>();
                    Parameters.TryAdd(parameter.Name, parameter.Value);
                }
            }
        }
    }

    protected virtual ValueTask OnClickAsync(GridRow<TItem> row, GridCellActionContext<TItem> context)
        => ValueTask.CompletedTask;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (CascadingContext.Column is { Actions: { } actions })
        {
            actions.Add(this);

            _isTemplate = true;
        }
    }

    protected override void OnParametersSet()
        => ParameterInvariant.IsNotEmpty(Name);

    private async Task OnClickHandlerAsync(MouseEventArgs e)
    {
        if (CascadingContext.Row is { } row && CascadingContext.Cell?.Context is GridCellActionContext<TItem> context)
        {
            await OnClickAsync(row, context);
        }
        else
        {
            throw new InvalidOperationException(
                $"The action cannot be executed due to a null value. Please check '{nameof(CascadingContext)}' for null.");
        }
    }
}