using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

public class BooleanFalseToNullStringConverter : JsonConverter<string?>
{
  public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.False)
    {
      return null;
    }
    if (reader.TokenType == JsonTokenType.String)
    {
      return reader.GetString();
    }
    return null;
  }

  public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteBooleanValue(false);
    }
    else
    {
      writer.WriteStringValue(value);
    }
  }
}