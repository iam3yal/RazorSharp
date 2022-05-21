namespace RazorSharp.Demo.Search;

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using RazorSharp.Demo.Data.Converters;

public sealed class JsonDictionaryConverter<TKey> : JsonConverter<IReadOnlyDictionary<TKey, StringBuilder>>
    where TKey : class
{
    private Dictionary<TKey, StringBuilder>? _di;

    public override IReadOnlyDictionary<TKey, StringBuilder>? Read(ref Utf8JsonReader reader,
                                                                   Type typeToConvert,
                                                                   JsonSerializerOptions options)
    {
        if (reader.TokenType is JsonTokenType.StartArray)
        {
            reader.Read();
        }

        BuildDictionary(ref reader, options);

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                break;
            }

            BuildDictionary(ref reader, options);
        }

        return _di;
    }

    public override void Write(Utf8JsonWriter writer,
                               IReadOnlyDictionary<TKey, StringBuilder> value,
                               JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private void BuildDictionary(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var obj = JsonSerializer.Deserialize<TKey>(ref reader, options);

        if (obj is null)
        {
            throw new JsonException();
        }

        var properties = obj.GetType().GetProperties();
        var searchData = new StringBuilder();

        foreach (var property in properties)
        {
            var value = property.GetValue(obj);

            if (value is not null)
            {
                var converter = options.GetConverter(property.PropertyType);

                if (converter.CanConvert(property.PropertyType))
                {
                    // REMARK: We should probably escape the CSV value when it contains a colon and semicolon but for brevity and considering that this is only a demo we can move on. 

                    searchData.Append($"{property.Name.ToLower()}:{ValueConverter.ToLowerString(value)};");
                }
                else
                {
                    throw new JsonException();
                }
            }
        }

        (_di ??= new Dictionary<TKey, StringBuilder>()).Add(obj, searchData);
    }
}