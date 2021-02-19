// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Base class for all order request types.
  /// </summary>
  public abstract class OrderRequest
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderRequest"/> class.
    /// </summary>
    [JsonConstructor]
    protected OrderRequest(
      OrderType type,
      TimeInForce timeInForce,
      DateTime? gtdTime,
      OrderTriggerCondition triggerCondition,
      ClientExtensions? clientExtensions)
    {
      if (timeInForce == TimeInForce.GTD)
      {
        if (!gtdTime.HasValue)
        {
          var message = $"'{nameof(gtdTime)}' must have a value when {nameof(timeInForce)} is '{nameof(TimeInForce.GTD)}'";
          throw new ArgumentException(message, nameof(gtdTime));
        }
      }
      else
      {
        if (gtdTime.HasValue)
        {
          var message = $"'{nameof(gtdTime)}' must NOT have a value when {nameof(timeInForce)} is not '{nameof(TimeInForce.GTD)}'";
          throw new ArgumentException(message, nameof(gtdTime));
        }
      }

      Type = type;
      TimeInForce = timeInForce;
      GtdTime = gtdTime;
      TriggerCondition = triggerCondition;
      ClientExtensions = clientExtensions;
    }

    /// <summary>
    /// The type of the Order to Create.
    /// </summary>
    public OrderType Type { get; }

    /// <summary>
    /// The time-in-force requested for the TrailingStopLoss Order. Restricted
    /// to“GTC”, “GFD” and “GTD” for TrailingStopLoss Orders.
    /// </summary>
    public TimeInForce TimeInForce { get; }

    /// <summary>
    /// The date/time when the StopLoss Order will be cancelled if its
    /// timeInForce is “GTD”.
    /// </summary>
    public DateTime? GtdTime { get; }

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
    /// The client extensions to add to the Order. Do not set, modify, or delete
    /// clientExtensions if your account is associated with MT4.
    /// </summary>
    public ClientExtensions? ClientExtensions { get; }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if the <paramref
    /// name="timeInForce"/> is not one of the <paramref name="allowed"/>
    /// values.
    /// </summary>
    /// <param name="timeInForce">The value being tested.</param>
    /// <param name="allowed">The allowed values.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref
    /// name="timeInForce"/> is not found in <paramref
    /// name="allowed"/>.</exception>
    protected static void ValidateTimeInForce(TimeInForce timeInForce, TimeInForce[] allowed)
    {
      if (Array.IndexOf(allowed, timeInForce) == -1)
      {
        var message = allowed.Length > 1
          ? $"'{nameof(timeInForce)}' must be one of the following values: {string.Join(',', allowed)}"
          : $"'{nameof(timeInForce)}' must be '{allowed[0]}'.";
        throw new ArgumentException(message, nameof(timeInForce));
      }
    }
  }
}
