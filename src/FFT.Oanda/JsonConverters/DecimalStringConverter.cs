// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.JsonConverters;

using System.Text.Json;
using System.Text.Json.Serialization;

internal sealed class DecimalStringConverter : JsonConverter<decimal>
{
  public override decimal Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      return decimal.Parse(reader.GetString()!);
    }

    return reader.GetDecimal();
  }

  public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    => writer.WriteStringValue(value.ToString());
}
