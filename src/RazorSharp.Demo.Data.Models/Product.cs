namespace RazorSharp.Demo.Data.Models;

using System.Text.Json.Serialization;

public sealed record Product
{
    public required string Brand { get; init; }

    public required string Description { get; set; }

    public required string Name { get; init; }

    [JsonIgnore]
    public int Price { get; set; }

    [JsonIgnore]
    public int Quantity { get; set; }
}