using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

/// <summary>
/// Converts empty strings to null decimal, otherwise parses valid decimal strings or numbers
/// </summary>
public class EmptyStringToNullableDecimalConverter : JsonConverter<decimal?>
{
  public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      var stringValue = reader.GetString();

      // Handle empty strings
      if (string.IsNullOrEmpty(stringValue))
      {
        return null;
      }

      // Try to parse valid decimal strings
      if (decimal.TryParse(stringValue, out var decimalValue))
      {
        return decimalValue;
      }

      // If parsing fails, return null
      return null;
    }

    if (reader.TokenType == JsonTokenType.Number)
    {
      return reader.GetDecimal();
    }

    if (reader.TokenType == JsonTokenType.Null)
    {
      return null;
    }

    // For any other type, return null
    return null;
  }

  public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
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

