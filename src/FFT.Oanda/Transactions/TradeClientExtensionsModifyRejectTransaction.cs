// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A TradeClientExtensionsModifyRejectTransaction represents the rejection of
/// the modification of a Trade’s Client Extensions.
/// </summary>
public sealed record TradeClientExtensionsModifyRejectTransaction : Transaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }

  // ----- Fields of the rejected transaction

  /// <summary>
  /// The ID of the Trade who’s client extensions are to be modified.
  /// </summary>
  public int TradeID { get; init; }

  /// <summary>
  /// The original Client ID of the Trade who’s client extensions are to be
  /// modified.
  /// </summary>
  public string? ClientTradeID { get; init; }

  /// <summary>
  /// The new Client Extensions for the Trade.
  /// </summary>
  public ClientExtensions TradeClientExtensionsModify { get; init; }
}
