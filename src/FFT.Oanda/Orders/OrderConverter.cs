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
      var copyReader = reader;
      var element = JsonSerializer.Deserialize<JsonElement>(ref copyReader, options);
      var typeElement = element.GetProperty("type");
      if (typeElement.ValueKind != JsonValueKind.String) throw new JsonException();
      var orderType = Enum.Parse<OrderType>(typeElement.GetString()!);
      return orderType switch
      {
        OrderType.LIMIT => JsonSerializer.Deserialize<LimitOrder>(ref reader, options),
        OrderType.MARKET => JsonSerializer.Deserialize<MarketOrder>(ref reader, options),
        OrderType.STOP => JsonSerializer.Deserialize<StopOrder>(ref reader, options),
        OrderType.MARKET_IF_TOUCHED => JsonSerializer.Deserialize<MarketIfTouchedOrder>(ref reader, options),
        OrderType.TAKE_PROFIT => JsonSerializer.Deserialize<TakeProfitOrder>(ref reader, options),
        OrderType.STOP_LOSS => JsonSerializer.Deserialize<StopLossOrder>(ref reader, options),
        OrderType.GUARANTEED_STOP_LOSS => JsonSerializer.Deserialize<GuaranteedStopLossOrder>(ref reader, options),
        OrderType.TRAILING_STOP_LOSS => JsonSerializer.Deserialize<TrailingStopLossOrder>(ref reader, options),
        OrderType.FIXED_PRICE => JsonSerializer.Deserialize<FixedPriceOrder>(ref reader, options),
        _ => throw new JsonException(),
      };
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Order value, JsonSerializerOptions options)
    {
      throw new NotSupportedException();
    }
  }
}
