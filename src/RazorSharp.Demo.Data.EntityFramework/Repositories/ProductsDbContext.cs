namespace RazorSharp.Demo.Data.EntityFramework.Repositories;

using System.Text.Json;

using Microsoft.EntityFrameworkCore;

using RazorSharp.Core.Contracts;
using RazorSharp.Demo.Data.Converters.Json;
using RazorSharp.Demo.Data.Models;

public sealed class ProductsDbContext : DbContext
{
    private const string ResourceFile = "RazorSharp.Demo.Data.EntityFramework.Documents.products.json";

    public ProductsDbContext(DbContextOptions options)
        : base(options)
    {
        Initialize();
    }

    public DbSet<Product>? Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);

    private void Initialize()
    {
        using var productsStream = typeof(ProductsDbContext).Assembly.GetManifestResourceStream(ResourceFile);

        Postcondition.IsNotNull(productsStream);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new JsonDecimalConverter());

        var products = JsonSerializer.Deserialize<Product[]>(productsStream, options);

        Postcondition.IsNotNull(products);

        foreach (var product in products)
        {
            Add(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Price = Random.Shared.Next(1, 1_000_000),
                Quantity = Random.Shared.Next(100)
            });
        }

        SaveChanges();
    }
}