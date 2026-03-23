using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

public class EmptyStringToNullableEnumConverter<T> : JsonConverter<T?> where T : struct, Enum
{
  public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      string? value = reader.GetString();
      if (string.IsNullOrWhiteSpace(value))
      {
        return null;
      }
      if (Enum.TryParse<T>(value, true, out T result))
      {
        return result;
      }
    }
    else if (reader.TokenType == JsonTokenType.Number)
    {
      int intValue = reader.GetInt32();
      if (Enum.IsDefined(typeof(T), intValue))
      {
        return (T)(object)intValue;
      }
    }
    return null;
  }

  public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
  {
    if (value.HasValue)
    {
      writer.WriteStringValue(value.Value.ToString());
    }
    else
    {
      writer.WriteStringValue("");
    }
  }
}