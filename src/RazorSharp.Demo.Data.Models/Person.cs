namespace RazorSharp.Demo.Data.Models;

using System;
using System.Text.Json.Serialization;

public sealed record Person
{
    public string? LastName { get; set; }

    public required DateOnly Birthday { get; init; }

    public required int Age { get; init; }

    public string? FavoriteColor { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Url { get; set; }

    public string? Company { get; set; }

    [JsonPropertyName("pan")]
    public string? PermanentAccountNumber { get; set; }

    public decimal TotalMoney { get; set; }

    public string? About { get; set; }

    public required int Id { get; init; }

    public required string FirstName { get; init; }

    public required string Region { get; init; }

    public required string Country { get; init; }

    public required DateTime CreatedDate { get; init; }
}