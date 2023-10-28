namespace RazorSharp.Components.Data;

using System.Collections;

using Microsoft.AspNetCore.Components.Web.Virtualization;

using RazorSharp.Framework;

public sealed partial class GridRows<TItem> : GridComponentBase<TItem>
    where TItem : class
{
    private IAsyncQueryExecutor? _asyncQueryExecutor;
    private IEnumerable<TItem> _currentNonVirtualizedViewItems = Array.Empty<TItem>();
    private object? _lastAssignedItemsOrProvider;
    private CancellationTokenSource? _pendingDataLoadCTS;
    private Virtualize<TItem>? _virtualizeComponent;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public RenderFragment<GridRowTemplateContext<TItem>>? RowTemplate { get; set; }

    [Inject]
    private IServiceProvider Services { get; set; } = default!;

    protected override void OnInitialized()
    {
        CascadingContext.Grid.OnRefresh -= RefreshDataAsync;
        CascadingContext.Grid.OnRefresh += RefreshDataAsync;
    }

    protected override async Task OnParametersSetAsync()
    {
        var grid = CascadingContext.Grid;

        // Perform a re-query only if the data source or something else has changed
        var newItemsOrItemsProvider = grid.Items ?? (object?) grid.ItemsProvider;
        var dataSourceHasChanged = newItemsOrItemsProvider != _lastAssignedItemsOrProvider;

        if (dataSourceHasChanged)
        {
            _lastAssignedItemsOrProvider = newItemsOrItemsProvider;

            if (grid.Items is IQueryable<TItem> queryableItems)
            {
                _asyncQueryExecutor = AsyncQueryExecutorSupplier.GetAsyncQueryExecutor(Services, queryableItems);
            }

            await RefreshDataAsync();
        }
        else
        {
            await Task.CompletedTask;
        }
    }

    // Gets called both by RefreshDataCoreAsync and directly by the Virtualize child component during scrolling
    private async ValueTask<ItemsProviderResult<TItem>> GetVirtualizedItems(ItemsProviderRequest request)
    {
        // Debounce the requests. This eliminates a lot of redundant queries at the cost of slight lag after interactions.
        // TODO: Consider making this configurable, or smarter (e.g., doesn't delay on first call in a batch, then the amount
        // of delay increases if you rapidly issue repeated requests, such as when scrolling a long way)
        await Task.Delay(100);

        if (request.CancellationToken.IsCancellationRequested)
        {
            return default;
        }

        var providerResult = await ResolveItemsRequestAsync(request);

        return !request.CancellationToken.IsCancellationRequested ? providerResult : default;
    }

    private async ValueTask RefreshDataAsync()
    {
        // Move into a "loading" state, cancelling any earlier-but-still-pending load
        _pendingDataLoadCTS?.Cancel();

        var pendingDataLoadCTS = _pendingDataLoadCTS = new CancellationTokenSource();

        if (_virtualizeComponent is not null)
        {
            // If we're using Virtualize, we have to go through its RefreshDataAsync API otherwise:
            // (1) It won't know to update its own internal state if the provider output has changed
            // (2) We won't know what slice of data to query for
            await _virtualizeComponent.RefreshDataAsync();

            _pendingDataLoadCTS = null;
        }
        else
        {
            // If we're not using Virtualize, we build and execute a request against the items provider directly
            var request = new ItemsProviderRequest(0, -1, pendingDataLoadCTS.Token);
            var result = await ResolveItemsRequestAsync(request);

            if (!pendingDataLoadCTS.IsCancellationRequested)
            {
                _currentNonVirtualizedViewItems = result.Items;
                _pendingDataLoadCTS = null;
            }
        }
    }

    // Normalizes all the different ways of configuring a data source so they have common GridItemsProvider-shaped API
    private async ValueTask<ItemsProviderResult<TItem>> ResolveItemsRequestAsync(ItemsProviderRequest request)
    {
        var grid = CascadingContext.Grid;

        if (grid.ItemsProvider is not null)
        {
            return await grid.ItemsProvider(request);
        }

        if (grid.Items is { } items)
        {
            int totalItemCount;

            if (items is IQueryable<TItem> queryableItems && _asyncQueryExecutor is not null)
            {
                totalItemCount = await _asyncQueryExecutor.CountAsync(queryableItems);
                items = await _asyncQueryExecutor.ToArrayAsync(queryableItems);
            }
            else
            {
                switch (items)
                {
                    case ICollection<TItem> c:
                    {
                        totalItemCount = c.Count;
                        break;
                    }
                    case ICollection c:
                    {
                        totalItemCount = c.Count;
                        break;
                    }
                    default:
                    {
                        var itemsArray = items.ToArray();
                        totalItemCount = itemsArray.Length;
                        items = itemsArray;
                        break;
                    }
                }
            }

            return new ItemsProviderResult<TItem>(items, totalItemCount);
        }

        return new ItemsProviderResult<TItem>(Array.Empty<TItem>(), 0);
    }
}