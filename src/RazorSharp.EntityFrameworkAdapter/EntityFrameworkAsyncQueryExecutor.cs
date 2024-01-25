namespace RazorSharp.EntityFrameworkAdapter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using RazorSharp.Framework;

internal sealed class EntityFrameworkAsyncQueryExecutor : IAsyncQueryExecutor
{
    public Task<int> CountAsync<T>(IQueryable<T> queryable)
        => queryable.CountAsync();

    public bool IsSupported<T>(IQueryable<T> queryable)
        => queryable.Provider is IAsyncQueryProvider;
}