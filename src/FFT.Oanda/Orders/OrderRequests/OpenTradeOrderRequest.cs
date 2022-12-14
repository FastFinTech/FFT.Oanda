// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// Base class for all order requests that will open a new trade.
/// </summary>
public abstract class OpenTradeOrderRequest : OrderRequest
{
  /// <summary>
  /// Initializes a new instance of the <see cref="OpenTradeOrderRequest"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  protected OpenTradeOrderRequest(
    OrderType type,
    TimeInForce timeInForce,
    DateTime? gtdTime,
    OrderTriggerCondition triggerCondition,
    ClientExtensions? clientExtensions,
    string instrument,
    OrderPositionFill positionFill,
    TakeProfitDetails? takeProfitOnFill,
    StopLossDetails? stopLossOnFill,
    GuaranteedStopLossDetails? guaranteedStopLossOnFill,
    TrailingStopLossDetails? trailingStopLossOnFill,
    ClientExtensions? tradeClientExtensions)
      : base(
          type,
          timeInForce,
          gtdTime,
          triggerCondition,
          clientExtensions)
  {
    if (string.IsNullOrWhiteSpace(instrument))
    {
      throw new ArgumentException($"'{nameof(instrument)}' cannot be empty.", nameof(instrument));
    }

    if (stopLossOnFill is not null && guaranteedStopLossOnFill is not null)
    {
      throw new ArgumentException($"Cannot have both '{nameof(stopLossOnFill)}' and '{nameof(guaranteedStopLossOnFill)}'.");
    }

    Instrument = instrument;
    PositionFill = positionFill;
    TakeProfitOnFill = takeProfitOnFill;
    StopLossOnFill = stopLossOnFill;
    GuaranteedStopLossOnFill = guaranteedStopLossOnFill;
    TrailingStopLossOnFill = trailingStopLossOnFill;
    TradeClientExtensions = tradeClientExtensions;
  }

  /// <summary>
  /// The Order’s Instrument.
  /// </summary>
  public string Instrument { get; }

  /// <summary>
  /// Specification of how Positions in the Account are modified when the
  /// Order is filled.
  /// </summary>
  public OrderPositionFill PositionFill { get; }

  /// <summary>
  /// TakeProfitDetails specifies the details of a Take Profit Order to be
  /// created on behalf of a client. This may happen when an Order is filled
  /// that opens a Trade requiring a Take Profit, or when a Trade’s dependent
  /// Take Profit Order is modified directly through the Trade.
  /// </summary>
  public TakeProfitDetails? TakeProfitOnFill { get; }

  /// <summary>
  /// StopLossDetails specifies the details of a Stop Loss Order to be created
  /// on behalf of a client. This may happen when an Order is filled that
  /// opens a Trade requiring a Stop Loss, or when a Trade’s dependent Stop
  /// Loss Order is modified directly through the Trade.
  /// </summary>
  public StopLossDetails? StopLossOnFill { get; }

  /// <summary>
  /// GuaranteedStopLossDetails specifies the details of a Guaranteed Stop
  /// Loss Order to be created on behalf of a client. This may happen when an
  /// Order is filled that opens a Trade requiring a Guaranteed Stop Loss, or
  /// when a Trade’s dependent Guaranteed Stop Loss Order is modified directly
  /// through the Trade.
  /// </summary>
  public GuaranteedStopLossDetails? GuaranteedStopLossOnFill { get; }

  /// <summary>
  /// TrailingStopLossDetails specifies the details of a Trailing Stop Loss
  /// Order to be created on behalf of a client. This may happen when an Order
  /// is filled that opens a Trade requiring a Trailing Stop Loss, or when a
  /// Trade’s dependent Trailing Stop Loss Order is modified directly through
  /// the Trade.
  /// </summary>
  public TrailingStopLossDetails? TrailingStopLossOnFill { get; }

  /// <summary>
  /// Client Extensions to add to the Trade created when the Order is filled
  /// (if such a Trade is created). Do not set, modify, or delete
  /// tradeClientExtensions if your account is associated with MT4.
  /// </summary>
  public ClientExtensions? TradeClientExtensions { get; }
}
