// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// The base Order definition specifies the properties that are common to all
  /// orders. Implemented by: MarketOrder, FixedPriceOrder, LimitOrder,
  /// StopOrder, MarketIfTouchedOrder, TakeProfitOrder, StopLossOrder,
  /// GuaranteedStopLossOrder, TrailingStopLossOrder.
  /// </summary>
  [JsonConverter(typeof(OrderConverter))]
  public abstract class Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Order"/> class.
    /// </summary>
    [JsonConstructor]
    protected Order(
      string id,
      DateTime createTime,
      OrderState state,
      ClientExtensions? clientExtensions,
      OrderType type,
      string instrument,
      TimeInForce timeInForce,
      DateTime? gtdTime,
      OrderPositionFill positionFill,
      OrderTriggerCondition triggerCondition,
      TakeProfitDetails? takeProfitOnFill,
      StopLossDetails? stopLossOnFill,
      GuaranteedStopLossDetails? guaranteedStopLossOnFill,
      TrailingStopLossDetails? trailingStopLossOnFill,
      ClientExtensions? tradeClientExtensions,
      string? fillingTransactionID,
      DateTime? filledTime,
      string? tradeOpenedID,
      string? tradeReducedID,
      ImmutableList<string>? tradeClosedIDs,
      string? cancellingTransactionID,
      DateTime? cancelledTime,
      string? replacesOrderID,
      string? replacedByOrderID)
    {
      Id = id;
      CreateTime = createTime;
      State = state;
      ClientExtensions = clientExtensions;
      Type = type;
      Instrument = instrument;
      TimeInForce = timeInForce;
      GtdTime = gtdTime;
      PositionFill = positionFill;
      TriggerCondition = triggerCondition;
      TakeProfitOnFill = takeProfitOnFill;
      StopLossOnFill = stopLossOnFill;
      GuaranteedStopLossOnFill = guaranteedStopLossOnFill;
      TrailingStopLossOnFill = trailingStopLossOnFill;
      TradeClientExtensions = tradeClientExtensions;
      FillingTransactionID = fillingTransactionID;
      FilledTime = filledTime;
      TradeOpenedID = tradeOpenedID;
      TradeReducedID = tradeReducedID;
      TradeClosedIDs = tradeClosedIDs;
      CancellingTransactionID = cancellingTransactionID;
      CancelledTime = cancelledTime;
      ReplacesOrderID = replacesOrderID;
      ReplacedByOrderID = replacedByOrderID;
    }

    /// <summary>
    /// The Order’s identifier, unique within the Order’s Account.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The time when the Order was created.
    /// </summary>
    public DateTime CreateTime { get; }

    /// <summary>
    /// The current state of the Order.
    /// </summary>
    public OrderState State { get; }

    /// <summary>
    /// The client extensions of the Order. Do not set, modify, or delete
    /// clientExtensions if your account is associated with MT4.
    /// </summary>
    public ClientExtensions? ClientExtensions { get; }

    /// <summary>
    /// The type of the Order.
    /// </summary>
    public OrderType Type { get; }

    /// <summary>
    /// The Order’s Instrument.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The time-in-force requested for the Order.
    /// </summary>
    public TimeInForce TimeInForce { get; }

    /// <summary>
    /// The date/time when the Order will be cancelled if its timeInForce
    /// is “GTD”.
    /// </summary>
    public DateTime? GtdTime { get; }

    /// <summary>
    /// Specification of how Positions in the Account are modified when the
    /// Order is filled.
    /// </summary>
    public OrderPositionFill PositionFill { get; }

    /// <summary>
    /// Specification of which price component should be used when determining
    /// if an Order should be triggered and filled. This allows Orders to be
    /// triggered based on the bid, ask, mid, default (ask for buy, bid for
    /// sell) or inverse (ask for sell, bid for buy) price depending on the
    /// desired behaviour. Orders are always filled using their default price
    /// component. This feature is only provided through the REST API. Clients
    /// who choose to specify a non-default trigger condition will not see it
    /// reflected in any of OANDA’s proprietary or partner trading platforms,
    /// their transaction history or their account statements. OANDA platforms
    /// always assume that an Order’s trigger condition is set to the default
    /// value when indicating the distance from an Order’s trigger price, and
    /// will always provide the default trigger condition when creating or
    /// modifying an Order. A special restriction applies when creating a
    /// Guaranteed Stop Loss Order. In this case the TriggerCondition value must
    /// either be “DEFAULT”, or the“natural” trigger side “DEFAULT” results in.
    /// So for a Guaranteed Stop Loss Order for a long trade valid values are
    /// “DEFAULT” and “BID”, and for short trades “DEFAULT” and “ASK” are valid.
    /// </summary>
    public OrderTriggerCondition TriggerCondition { get; }

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

    /// <summary>
    /// ID of the Transaction that filled this Order (only provided when the
    /// Order’s state is FILLED).
    /// </summary>
    public string? FillingTransactionID { get; }

    /// <summary>
    /// Date/time when the Order was filled (only provided when the Order’s
    /// state is FILLED).
    /// </summary>
    public DateTime? FilledTime { get; }

    /// <summary>
    /// Trade ID of Trade opened when the Order was filled (only provided when
    /// the Order’s state is FILLED and a Trade was opened as a result of the
    /// fill).
    /// </summary>
    public string? TradeOpenedID { get; }

    /// <summary>
    /// Trade ID of Trade reduced when the Order was filled (Only provided when
    /// the Order’s state is FILLED and a Trade was reduced as a result of the
    /// fill).
    /// </summary>
    public string? TradeReducedID { get; }

    /// <summary>
    /// Trade IDs of Trades closed when the Order was filled (Only provided when
    /// the Order’s state is FILLED and one or more Trades were closed as a
    /// result of the fill).
    /// </summary>
    public ImmutableList<string>? TradeClosedIDs { get; }

    /// <summary>
    /// ID of the Transaction that cancelled the Order (Only provided when the
    /// Order’s state is CANCELLED).
    /// </summary>
    public string? CancellingTransactionID { get; }

    /// <summary>
    /// Date/time when the Order was cancelled (only provided when the state of
    /// the Order is CANCELLED).
    /// </summary>
    public DateTime? CancelledTime { get; }

    /// <summary>
    /// The ID of the Order that was replaced by this Order (only provided if
    /// this Order was created as part of a cancel/replace).
    /// </summary>
    public string? ReplacesOrderID { get; }

    /// <summary>
    /// The ID of the Order that replaced this Order (only provided if this
    /// Order was cancelled as part of a cancel/replace).
    /// </summary>
    public string? ReplacedByOrderID { get; }
  }
}
