using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Apigen.InvoiceNinja.Models;

public class EmptyStringToNullableDecimalConverter : JsonConverter<decimal?>
{
  public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      string? value = reader.GetString();
      if (string.IsNullOrWhiteSpace(value))
      {
        return null;
      }
      if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
      {
        return result;
      }
    }
    else if (reader.TokenType == JsonTokenType.Number)
    {
      return reader.GetDecimal();
    }
    return null;
  }

  public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
  {
    if (value.HasValue)
    {
      writer.WriteStringValue(value.Value.ToString(CultureInfo.InvariantCulture));
    }
    else
    {
      writer.WriteStringValue("");
    }
  }
}