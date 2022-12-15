// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.JsonConverters;

internal sealed class ResettablePLDateConverter : JsonConverter<DateTime?>
{
  public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var unixMilliSeconds = reader.TokenType == JsonTokenType.String
      ? long.Parse(reader.GetString()!, NumberStyles.Any, InvariantCulture)
      : reader.GetInt64();
    if (unixMilliSeconds == 0) return null;
    return DateTimeOffset.FromUnixTimeMilliseconds(unixMilliSeconds).DateTime;
  }

  public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    => throw new NotSupportedException();
}
