// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Collections.Immutable;
using System.Text.Json.Serialization;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.SetOrderClientExtensions(string, string, ClientExtensions?, ClientExtensions?, CancellationToken)"/>
/// method when the request is successful.
/// </summary>
public sealed class UpdateOrderClientExtensionsResponse
{
  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="UpdateOrderClientExtensionsResponse"/> class.
  /// </summary>
  [JsonConstructor]
  public UpdateOrderClientExtensionsResponse(
    OrderClientExtensionsModifyTransaction orderClientExtensionsModifyTransaction,
    int lastTransactionID,
    ImmutableList<string> relatedTransactionIDs)
  {
    OrderClientExtensionsModifyTransaction = orderClientExtensionsModifyTransaction;
    LastTransactionID = lastTransactionID;
    RelatedTransactionIDs = relatedTransactionIDs;
  }

  /// <summary>
  /// The Transaction that modified the Client Extensions for the Order.
  /// </summary>
  public OrderClientExtensionsModifyTransaction OrderClientExtensionsModifyTransaction { get; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; }

  /// <summary>
  /// The IDs of all Transactions that were created while satisfying the
  /// request.
  /// </summary>
  public ImmutableList<string> RelatedTransactionIDs { get; }
}
