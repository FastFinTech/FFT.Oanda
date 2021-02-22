// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetSingleOrder(string, string)"/> method. Contains information about the single order.
  /// </summary>
  public sealed class GetSingleOrderResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSingleOrderResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public GetSingleOrderResponse(
      Order order,
      string lastTransactionId)
    {
      Order = order;
      LastTransactionId = lastTransactionId;
    }

    /// <summary>
    /// The details of the Order requested. Actual instance type will vary
    /// depending on the order type.
    /// </summary>
    public Order Order { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionId { get; }
  }

}
