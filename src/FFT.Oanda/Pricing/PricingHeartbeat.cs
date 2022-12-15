// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing;

/// <summary>
/// A PricingHeartbeat object is injected into the Pricing stream to ensure
/// that the HTTP connection remains active.
/// </summary>
public sealed record PricingHeartbeat
{
  /// <summary>
  /// The string “HEARTBEAT”.
  /// </summary>
  public string Type { get; init; }

  /// <summary>
  /// The date/time when the Heartbeat was created.
  /// </summary>
  public DateTime Time { get; init; }
}
