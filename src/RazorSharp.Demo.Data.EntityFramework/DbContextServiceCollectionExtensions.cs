namespace RazorSharp.Demo.Data.EntityFramework;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using RazorSharp.Demo.Data.EntityFramework.Repositories;

public static class DbContextServiceCollectionExtensions
{
    public static void AddProductsDbContext(this IServiceCollection services)
    {
        var connection = new SqliteConnection("Data Source=products.sqlite3;Mode=Memory;Cache=Shared");
        connection.Open();

        using var productsConnection = new SqliteConnection(connection.ConnectionString);
        productsConnection.Open();

        var createCommand = productsConnection.CreateCommand();
        createCommand.CommandText = """
                                    CREATE TABLE IF NOT EXISTS Products (
                                        Id INTEGER NOT NULL PRIMARY KEY,
                                        Name TEXT,
                                        Description TEXT,
                                        Brand TEXT,
                                        Price INTEGER,
                                        Quantity INTEGER
                                    )
                                    """;
        createCommand.ExecuteNonQuery();

        services.AddDbContext<ProductsDbContext>(b => b.UseSqlite(connection));
    }
}