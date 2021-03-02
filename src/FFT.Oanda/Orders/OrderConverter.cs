// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Text.Json;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Provides a way for inherited order types to be deserialized by parsing the
  /// <see cref="Order.Type"/> property to determine the appropriate type for
  /// deserialization.
  /// </summary>
  public sealed class OrderConverter : JsonConverter<Order>
  {
    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
      => typeToConvert == typeof(Order);

    /// <inheritdoc/>
    public override Order? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var type = reader.ExtractTypePropertyWithoutMutatingReaderState();
      return PolymorphicDeserializer.DeserializeOrder(type, ref reader);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Order value, JsonSerializerOptions options)
      => throw new NotSupportedException();
  }
}
