namespace RazorSharp.Demo.Search.DataServer.Services;

using RazorSharp.Core.Contracts;
using RazorSharp.Demo.Data.Abstractions.Services;

public sealed class PeopleDataService : BackgroundService
{
    private readonly IServiceProvider _services;

    private readonly TaskCompletionSource _source = new ();

    public PeopleDataService(IServiceProvider services, IHostApplicationLifetime lifetime)
    {
        Precondition.IsNotNull(services);
        Precondition.IsNotNull(lifetime);

        _services = services;

        lifetime.ApplicationStarted.Register(() => _source.SetResult());
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var tcs = new TaskCompletionSource();
        stoppingToken.Register(() => tcs.SetResult());

        await Task.WhenAny(tcs.Task, _source.Task).ConfigureAwait(false);

        if (stoppingToken.IsCancellationRequested)
        {
            return;
        }

        using var scope = _services.CreateScope();

        var dataProvider = scope.ServiceProvider.GetRequiredService<IDataLoader>();

        await dataProvider.LoadDataAsync();
    }
}