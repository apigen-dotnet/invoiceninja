using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

public class StringToIntegerConverter : JsonConverter<int?>
{
  public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      string? value = reader.GetString();
      if (int.TryParse(value, out int result))
      {
        return result;
      }
      return null;
    }
    else if (reader.TokenType == JsonTokenType.Number)
    {
      return reader.GetInt32();
    }
    return null;
  }

  public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
  {
    if (value.HasValue)
    {
      writer.WriteStringValue(value.Value.ToString());
    }
    else
    {
      writer.WriteNullValue();
    }
  }
}