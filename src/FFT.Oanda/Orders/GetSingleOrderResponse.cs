// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetSingleOrder(string, string, CancellationToken)"/> method.
/// Contains information about the single order.
/// </summary>
public sealed record GetSingleOrderResponse
{
  /// <summary>
  /// The details of the Order requested. Actual instance type will vary
  /// depending on the order type.
  /// </summary>
  public Order Order { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
