namespace RazorSharp.Demo.Data.Converters.Json;

using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class JsonDateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateOnlyConverter.FromString(reader.GetString()!);

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(DateOnlyConverter.ToString(value));
}