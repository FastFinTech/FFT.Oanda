// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.JsonConverters;

using System.Text.Json;
using System.Text.Json.Serialization;

internal sealed class Int32StringConverter : JsonConverter<int>
{
  public override int Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.String)
    {
      return int.Parse(reader.GetString()!, NumberStyles.Any, InvariantCulture);
    }

    return reader.GetInt32();
  }

  public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    => writer.WriteStringValue(value.ToString(InvariantCulture));
}
