// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A PricingHeartbeat object is injected into the Pricing stream to ensure
/// that the HTTP connection remains active.
/// </summary>
public sealed class PricingHeartbeat
{
  /// <summary>
  /// Initializes a new instance of the <see cref="PricingHeartbeat"/> class.
  /// </summary>
  [JsonConstructor]
  public PricingHeartbeat(
    string type,
    DateTime time)
  {
    Type = type;
    Time = time;
  }

  /// <summary>
  /// The string “HEARTBEAT”.
  /// </summary>
  public string Type { get; }

  /// <summary>
  /// The date/time when the Heartbeat was created.
  /// </summary>
  public DateTime Time { get; }
}
