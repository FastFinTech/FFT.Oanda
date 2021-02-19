// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// An OrderIdentifier is used to refer to an Order, and contains both the
  /// OrderID and the ClientOrderID.
  /// </summary>
  public sealed class OrderIdentifier
  {
    // TODO:"clientOrderId" should probably be made nullable.

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderIdentifier"/> class.
    /// </summary>
    [JsonConstructor]
    public OrderIdentifier(
      string orderId,
      string clientOrderId)
    {
      OrderId = orderId;
      ClientOrderId = clientOrderId;
    }

    /// <summary>
    /// The OANDA-assigned Order ID.
    /// </summary>
    public string OrderId { get; }

    /// <summary>
    /// The client-provided client Order ID.
    /// </summary>
    public string ClientOrderId { get; }
  }
}
