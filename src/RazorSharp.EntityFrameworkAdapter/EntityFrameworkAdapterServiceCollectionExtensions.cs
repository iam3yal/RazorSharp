namespace RazorSharp.EntityFrameworkAdapter;

using Microsoft.Extensions.DependencyInjection;

using RazorSharp.Framework;

/// <summary>
///     Provides extension methods to configure <see cref="IAsyncQueryExecutor" /> on a <see cref="IServiceCollection" />.
/// </summary>
public static class EntityFrameworkAdapterServiceCollectionExtensions
{
    /// <summary>
    ///     Registers an Entity Framework aware implementation of <see cref="IAsyncQueryExecutor" />.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" />.
    /// </param>
    public static void AddRazorSharpEntityFrameworkAdapter(this IServiceCollection services)
        => services.AddSingleton<IAsyncQueryExecutor, EntityFrameworkAsyncQueryExecutor>();
}