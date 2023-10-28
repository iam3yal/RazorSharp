namespace RazorSharp.Demo.Data.EntityFramework.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RazorSharp.Demo.Data.Models;

public sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property<int>("Id")
               .HasColumnType("int")
               .ValueGeneratedOnAdd()
               .HasAnnotation("Key", 0);
    }
}