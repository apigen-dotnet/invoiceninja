using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

public class UnixTimestampConverter : JsonConverter<DateTimeOffset?>
{
  public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.Number)
    {
      var timestamp = reader.GetDecimal();
      return DateTimeOffset.FromUnixTimeSeconds((long)timestamp);
    }
    return null;
  }

  public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
  {
    if (value.HasValue)
      writer.WriteNumberValue(value.Value.ToUnixTimeSeconds());
    else
      writer.WriteNullValue();
  }
}
