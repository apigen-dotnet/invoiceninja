using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

/// <summary>
/// Converts JSON string numbers to integers (e.g., "30" -> 30, "-1" -> -1)
/// </summary>
public class StringToIntegerConverter : JsonConverter<int?>
{
  public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      var stringValue = reader.GetString();
      if (string.IsNullOrEmpty(stringValue))
      {
        return null;
      }

      if (int.TryParse(stringValue, out var intValue))
      {
        return intValue;
      }

      // If parsing fails, return null or throw exception
      return null;
    }

    if (reader.TokenType == JsonTokenType.Number)
    {
      return reader.GetInt32();
    }

    if (reader.TokenType == JsonTokenType.Null)
    {
      return null;
    }

    // For any other type, return null
    return null;
  }

  public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteNullValue();
    }
    else
    {
      writer.WriteNumberValue(value.Value);
    }
  }
}

