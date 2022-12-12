// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetOrders(string, string?, OrderStateFilter, int, string, string[], CancellationToken)"/> and the <see
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
      string lastTransactionId)
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
    public string LastTransactionId { get; }
  }
}
