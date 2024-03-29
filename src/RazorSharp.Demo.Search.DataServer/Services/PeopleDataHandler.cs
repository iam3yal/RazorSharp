namespace RazorSharp.Demo.Search.DataServer.Services;

using System.Collections.Immutable;
using System.Text;
using System.Text.Json;

using RazorSharp.Core.Contracts;
using RazorSharp.Demo.Data.Abstractions.Services;
using RazorSharp.Demo.Data.Converters.Json;
using RazorSharp.Demo.Data.Models;

public sealed class PeopleDataHandler : IDataProvider<IReadOnlyDictionary<Person, StringBuilder>>, IDataLoader
{
    private const string DataFile = "RazorSharp.Demo.Search.DataServer.Documents.people.json";

    private IReadOnlyDictionary<Person, StringBuilder>? _data;

    public IReadOnlyDictionary<Person, StringBuilder> GetData()
        => _data ?? ImmutableDictionary<Person, StringBuilder>.Empty;

    public async Task LoadDataAsync()
    {
        await using var stream = typeof(PeopleDataHandler).Assembly
                                                          .GetManifestResourceStream(DataFile);

        Postcondition.IsNotNull(stream);

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        options.Converters.Add(new JsonDecimalConverter());
        options.Converters.Add(new JsonDateOnlyConverter());
        options.Converters.Add(new JsonDateTimeConverter());
        options.Converters.Add(new JsonDictionaryConverter<Person>());

        _data = await JsonSerializer.DeserializeAsync<IReadOnlyDictionary<Person, StringBuilder>>(stream, options);
    }
}