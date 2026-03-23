using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

/// <summary>
/// Converts JSON boolean false to null string, otherwise tries to read as string
/// </summary>
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

    if (reader.TokenType == JsonTokenType.Null)
    {
      return null;
    }

    // For any other type, try to convert to string
    return reader.GetString();
  }

  public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteNullValue();
    }
    else
    {
      writer.WriteStringValue(value);
    }
  }
}

