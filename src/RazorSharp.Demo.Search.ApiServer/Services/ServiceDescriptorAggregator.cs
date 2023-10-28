namespace RazorSharp.Demo.Search.ApiServer.Services;

using System.Collections;

public sealed class ServiceDescriptorAggregator : IEnumerable<ServiceDescriptor>
{
    private readonly IList<ServiceDescriptor> _services = new List<ServiceDescriptor>();

    private object? _implementationInstance;

    public IEnumerator<ServiceDescriptor> GetEnumerator()
        => _services.GetEnumerator();

    public ServiceDescriptorAggregator Singleton<TService>(TService implementationInstance)
        where TService : class
    {
        if (_implementationInstance is null)
        {
            _services.Add(ServiceDescriptor.Singleton(implementationInstance));

            _implementationInstance = implementationInstance;
        }
        else
        {
            throw new InvalidOperationException();
        }

        return this;
    }

    public ServiceDescriptorAggregator Singleton<TService>()
        where TService : class
    {
        if (_implementationInstance is not null)
        {
            _services.Add(ServiceDescriptor.Singleton(typeof(TService), _implementationInstance));
        }
        else
        {
            throw new InvalidOperationException();
        }

        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}