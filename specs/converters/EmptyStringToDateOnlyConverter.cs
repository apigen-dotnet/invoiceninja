using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

public class EmptyStringToDateOnlyConverter : JsonConverter<DateOnly?>
{
  public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      string? value = reader.GetString();
      if (string.IsNullOrWhiteSpace(value))
      {
        return null;
      }
      if (DateOnly.TryParse(value, out DateOnly result))
      {
        return result;
      }
    }
    return null;
  }

  public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
  {
    if (value.HasValue)
    {
      writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
    }
    else
    {
      writer.WriteStringValue("");
    }
  }
}