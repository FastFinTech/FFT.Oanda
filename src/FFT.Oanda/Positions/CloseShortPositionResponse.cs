// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions;

using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.CloseShortPosition(string, string, NumUnits, ClientExtensions?, CancellationToken)"/>  method.
/// </summary>
public sealed record CloseShortPositionResponse
{
  /// <summary>
  /// The MarketOrderTransaction created to close the short Position.
  /// </summary>
  public MarketOrderTransaction? ShortOrderCreateTransaction { get; init; }

  /// <summary>
  /// OrderFill Transaction that closes the short Position.
  /// </summary>
  public OrderFillTransaction? ShortOrderFillTransaction { get; init; }

  /// <summary>
  /// OrderCancel Transaction that cancels the MarketOrder created to close
  /// the short Position.
  /// </summary>
  public OrderCancelTransaction? ShortOrderCancelTransaction { get; init; }

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
