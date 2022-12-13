// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetOrders(string, string?, OrderStateFilter, int, int?, int[], CancellationToken)"/> and the <see
/// cref="OandaApiClient.GetPendingOrders(string, CancellationToken)"/> methods.
/// </summary>
public sealed class GetOrdersResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="GetOrdersResponse"/> class.
  /// </summary>
  [JsonConstructor]
  public GetOrdersResponse(
    ImmutableList<Order> orders,
    int lastTransactionId)
  {
    Orders = orders;
    LastTransactionId = lastTransactionId;
  }

  /// <summary>
  /// The list of Order detail objects. Actual object instance type depends on
  /// the type of order.
  /// </summary>
  public ImmutableList<Order> Orders { get; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; }
}
