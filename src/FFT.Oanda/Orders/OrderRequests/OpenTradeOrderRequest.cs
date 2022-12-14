// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;
/// <summary>
/// Base class for all order requests that will open a new trade.
/// </summary>
public abstract record OpenTradeOrderRequest : OrderRequest
{
  protected sealed override void CustomValidate()
  {
    if (string.IsNullOrWhiteSpace(Instrument))
    {
      throw new ArgumentException($"'{nameof(Instrument)}' cannot be empty.", nameof(Instrument));
    }

    if (StopLossOnFill is not null && GuaranteedStopLossOnFill is not null)
    {
      throw new ArgumentException($"Cannot have both '{nameof(StopLossOnFill)}' and '{nameof(GuaranteedStopLossOnFill)}'.");
    }

    CustomValidate2();
  }

  protected abstract void CustomValidate2();

  /// <summary>
  /// The Order’s Instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// Specification of how Positions in the Account are modified when the
  /// Order is filled.
  /// </summary>
  public OrderPositionFill PositionFill { get; init; }

  /// <summary>
  /// TakeProfitDetails specifies the details of a Take Profit Order to be
  /// created on behalf of a client. This may happen when an Order is filled
  /// that opens a Trade requiring a Take Profit, or when a Trade’s dependent
  /// Take Profit Order is modified directly through the Trade.
  /// </summary>
  public TakeProfitDetails? TakeProfitOnFill { get; init; }

  /// <summary>
  /// StopLossDetails specifies the details of a Stop Loss Order to be created
  /// on behalf of a client. This may happen when an Order is filled that
  /// opens a Trade requiring a Stop Loss, or when a Trade’s dependent Stop
  /// Loss Order is modified directly through the Trade.
  /// </summary>
  public StopLossDetails? StopLossOnFill { get; init; }

  /// <summary>
  /// GuaranteedStopLossDetails specifies the details of a Guaranteed Stop
  /// Loss Order to be created on behalf of a client. This may happen when an
  /// Order is filled that opens a Trade requiring a Guaranteed Stop Loss, or
  /// when a Trade’s dependent Guaranteed Stop Loss Order is modified directly
  /// through the Trade.
  /// </summary>
  public GuaranteedStopLossDetails? GuaranteedStopLossOnFill { get; init; }

  /// <summary>
  /// TrailingStopLossDetails specifies the details of a Trailing Stop Loss
  /// Order to be created on behalf of a client. This may happen when an Order
  /// is filled that opens a Trade requiring a Trailing Stop Loss, or when a
  /// Trade’s dependent Trailing Stop Loss Order is modified directly through
  /// the Trade.
  /// </summary>
  public TrailingStopLossDetails? TrailingStopLossOnFill { get; init; }

  /// <summary>
  /// Client Extensions to add to the Trade created when the Order is filled
  /// (if such a Trade is created). Do not set, modify, or delete
  /// tradeClientExtensions if your account is associated with MT4.
  /// </summary>
  public ClientExtensions? TradeClientExtensions { get; init; }
}
