namespace RazorSharp.Demo.Data.Converters.Json;

using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class JsonDecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType is JsonTokenType.String
            ? DecimalConverter.FromString(reader.GetString()!)
            : default;

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        => writer.WriteStringValue(DecimalConverter.ToString(value));
}