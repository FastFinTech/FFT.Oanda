// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.SetOrderClientExtensions(string, string, ClientExtensions?, ClientExtensions?, CancellationToken)"/>
/// method when the request is successful.
/// </summary>
public sealed record UpdateOrderClientExtensionsResponse
{
  /// <summary>
  /// The Transaction that modified the Client Extensions for the Order.
  /// </summary>
  public OrderClientExtensionsModifyTransaction OrderClientExtensionsModifyTransaction { get; init; }

  /// <summary>
  /// The IDs of all Transactions that were created while satisfying the
  /// request.
  /// </summary>
  public ImmutableList<int> RelatedTransactionIDs { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; init; }
}
