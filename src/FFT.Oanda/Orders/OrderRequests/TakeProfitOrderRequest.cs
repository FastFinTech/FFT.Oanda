// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A TakeProfitOrderRequest specifies the parameters that may be set when
/// creating a Take Profit Order.
/// </summary>
public sealed class TakeProfitOrderRequest : CloseTradeOrderRequest
{
  private static readonly TimeInForce[] _allowed = new[]
  {
    TimeInForce.GTC,
    TimeInForce.GFD,
    TimeInForce.GTD,
  };

  /// <summary>
  /// Initializes a new instance of the <see cref="TakeProfitOrderRequest"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public TakeProfitOrderRequest(
    TimeInForce timeInForce,
    DateTime? gtdTime,
    OrderTriggerCondition triggerCondition,
    ClientExtensions? clientExtensions,
    string tradeID,
    string? clientTradeID,
    decimal price)
      : base(
          OrderType.TAKE_PROFIT,
          timeInForce,
          gtdTime,
          triggerCondition,
          clientExtensions,
          tradeID,
          clientTradeID)
  {
    ValidateTimeInForce(timeInForce, _allowed);
    Price = price;
  }

  /// <summary>
  /// The price threshold specified for the TakeProfit Order. The associated
  /// Trade will be closed by a market price that is equal to or better than
  /// this threshold.
  /// </summary>
  public decimal Price { get; }
}
