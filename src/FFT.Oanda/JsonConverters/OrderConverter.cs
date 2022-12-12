// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.JsonConverters;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FFT.Oanda.Orders;

internal sealed class OrderConverter : JsonConverter<Order>
{
  public override Order? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var type = reader.ExtractTypePropertyWithoutMutatingReaderState();
    return PolymorphicDeserializer.DeserializeOrder(type, ref reader);
  }

  public override void Write(Utf8JsonWriter writer, Order value, JsonSerializerOptions options)
    => throw new NotSupportedException();
}
