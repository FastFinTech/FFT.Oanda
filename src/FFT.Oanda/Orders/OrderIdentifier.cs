// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// An OrderIdentifier is used to refer to an Order, and contains both the
/// OrderID and the ClientOrderID.
/// </summary>
public sealed record OrderIdentifier
{
  /// <summary>
  /// The OANDA-assigned Order ID.
  /// </summary>
  public int OrderId { get; init; }

  /// <summary>
  /// The client-provided client Order ID.
  /// </summary>
  public string? ClientOrderId { get; init; }
}
