﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The dynamic state of an Order. This is only relevant to TrailingStopLoss
  /// Orders, as no other Order type has dynamic state.
  /// </summary>
  public sealed class DynamicOrderState
  {
    // TODO: Determine if TriggerDistance "not set" is null or 0.

    // TODO: Determine if IsTriggerDistanceExact "not set" is null or 0.

    /// <summary>
    /// Initializes a new instance of the <see cref="DynamicOrderState"/> class.
    /// </summary>
    [JsonConstructor]
    public DynamicOrderState(
      string id,
      decimal trailingStopValue,
      decimal? triggerDistance,
      bool? isTriggerDistanceExact)
    {
      Id = id;
      TrailingStopValue = trailingStopValue;
      TriggerDistance = triggerDistance;
      IsTriggerDistanceExact = isTriggerDistanceExact;
    }

    /// <summary>
    /// The Order’s ID.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The Order’s calculated trailing stop value.
    /// </summary>
    public decimal TrailingStopValue { get; }

    /// <summary>
    /// The distance between the Trailing Stop Loss Order’s trailingStopValue
    /// and the current Market Price. This represents the distance (in price
    /// units) of the Order from a triggering price. If the distance could not
    /// be determined, this value will not be set.
    /// </summary>
    public decimal? TriggerDistance { get; }

    /// <summary>
    /// True if an exact trigger distance could be calculated. If false, it
    /// means the provided trigger distance is a best estimate. If the distance
    /// could not be determined, this value will not be set.
    /// </summary>
    public bool? IsTriggerDistanceExact { get; }
  }
}
