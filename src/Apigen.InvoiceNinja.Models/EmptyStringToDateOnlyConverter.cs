using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

/// <summary>
/// Converts empty strings to null DateOnly, otherwise parses valid date strings
/// </summary>
public class EmptyStringToDateOnlyConverter : JsonConverter<DateOnly?>
{
  public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      var stringValue = reader.GetString();

      // Handle empty strings
      if (string.IsNullOrEmpty(stringValue))
      {
        return null;
      }

      // Try to parse valid date strings
      if (DateOnly.TryParse(stringValue, out var dateValue))
      {
        return dateValue;
      }

      // If parsing fails, return null
      return null;
    }

    if (reader.TokenType == JsonTokenType.Null)
    {
      return null;
    }

    // For any other type, return null
    return null;
  }

  public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteNullValue();
    }
    else
    {
      writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
    }
  }
}

