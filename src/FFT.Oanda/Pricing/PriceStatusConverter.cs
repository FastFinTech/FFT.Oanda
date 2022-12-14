// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// This custom converter is needed to deserialize PriceStatus values because
/// the oanda api returns values that contain characters that are invalid for
/// use in an enum value's name.
/// </summary>
internal class PriceStatusConverter : JsonConverter<PriceStatus>
{
  public override bool CanConvert(System.Type typeToConvert)
    => typeToConvert == typeof(PriceStatus);

  public override PriceStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType != JsonTokenType.String)
      throw new JsonException();

    return reader.GetString() switch
    {
      "tradeable" => PriceStatus.TRADEABLE,
      "non-tradeable" => PriceStatus.NONTRADEABLE,
      "invalid" => PriceStatus.INVALID,
      _ => throw new JsonException(),
    };
  }

  public override void Write(Utf8JsonWriter writer, PriceStatus value, JsonSerializerOptions options)
    => throw new NotSupportedException();
}
