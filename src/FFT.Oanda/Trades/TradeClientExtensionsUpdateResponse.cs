// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.SetTradeClientExtensions(string, string, ClientExtensions, CancellationToken)"/> method.
/// </summary>
public sealed record TradeClientExtensionsUpdateResponse
{
  /// <summary>
  /// The Transaction that updates the Trade’s Client Extensions.
  /// </summary>
  public TradeClientExtensionsModifyTransaction TradeClientExtensionsModifyTransaction { get; init; }

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
