using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

/// <summary>
/// Converts empty strings to null for nullable enum types
/// </summary>
public class EmptyStringToNullableEnumConverter<T> : JsonConverter<T?> where T : struct, Enum
{
  public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      var stringValue = reader.GetString();

      // Handle empty strings
      if (string.IsNullOrEmpty(stringValue))
      {
        return null;
      }

      // Try to parse the enum value
      if (Enum.TryParse<T>(stringValue, true, out var enumValue))
      {
        return enumValue;
      }

      // Handle numeric strings for enums (e.g., "1" -> EnumValue._1)
      if (int.TryParse(stringValue, out var intValue))
      {
        // Try with underscore prefix for numeric enum values
        var underscoreName = "_" + intValue;
        if (Enum.TryParse<T>(underscoreName, true, out enumValue))
        {
          return enumValue;
        }

        // Try casting the integer directly
        if (Enum.IsDefined(typeof(T), intValue))
        {
          return (T)(object)intValue;
        }
      }

      // If we can't parse it, return null
      return null;
    }

    if (reader.TokenType == JsonTokenType.Number)
    {
      var intValue = reader.GetInt32();

      // Try with underscore prefix for numeric enum values
      var underscoreName = "_" + intValue;
      if (Enum.TryParse<T>(underscoreName, true, out var enumValue))
      {
        return enumValue;
      }

      // Try casting the integer directly
      if (Enum.IsDefined(typeof(T), intValue))
      {
        return (T)(object)intValue;
      }

      return null;
    }

    if (reader.TokenType == JsonTokenType.Null)
    {
      return null;
    }

    return null;
  }

  public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteNullValue();
    }
    else
    {
      // Write the numeric value if the enum name starts with underscore
      var enumName = value.ToString();
      if (enumName?.StartsWith("_") == true && int.TryParse(enumName.Substring(1), out var numericValue))
      {
        writer.WriteStringValue(numericValue.ToString());
      }
      else
      {
        writer.WriteStringValue(value.ToString());
      }
    }
  }
}

