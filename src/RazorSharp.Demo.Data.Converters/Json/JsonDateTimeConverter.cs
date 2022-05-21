namespace RazorSharp.Demo.Data.Converters.Json;

using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class JsonDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTimeConverter.FromString(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(DateTimeConverter.ToString(value));
}