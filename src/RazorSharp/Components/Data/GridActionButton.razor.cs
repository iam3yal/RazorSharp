namespace RazorSharp.Components.Data;

using Microsoft.AspNetCore.Components.Web;

public partial class GridActionButton<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    private bool _isTemplate;

    public GridEditState EditState { get; protected set; } = GridEditState.None;

    [Parameter]
    public string? Name { get; set; }

    internal Dictionary<string, object?>? Parameters { get; private set; }

    public async ValueTask ClickAsync()
    {
        if (CascadingContext.Row is { } row)
        {
            if (EditState is GridEditState.Read)
            {
                await row.ChangeEditStateAsync(GridEditState.Write);
            }
            else
            {
                await row.ChangeEditStateAsync(GridEditState.Read);
            }

            await OnClickHandlerAsync(row);
        }
        else
        {
            throw new InvalidOperationException(
                $"The action cannot be handled. '{nameof(CascadingContext.Row)}' is null");
        }
    }

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

    protected virtual ValueTask OnClickHandlerAsync(GridRow<TItem> row)
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

    private async Task OnClickHandlerAsync(MouseEventArgs e)
        => await ClickAsync();
}