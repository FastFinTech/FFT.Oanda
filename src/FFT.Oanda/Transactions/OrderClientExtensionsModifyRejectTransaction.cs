// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// A OrderClientExtensionsModifyRejectTransaction represents the rejection of
/// the modification of an Order’s Client Extensions.
/// </summary>
public sealed record OrderClientExtensionsModifyRejectTransaction : Transaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }

  // ----- Fields of the rejected transaction

  /// <summary>
  /// The ID of the Order who’s client extensions are to be modified.
  /// </summary>
  public int OrderID { get; init; }

  /// <summary>
  /// The original Client ID of the Order who’s client extensions are to be
  /// modified.
  /// </summary>
  public string? ClientOrderID { get; init; }

  /// <summary>
  /// The new Client Extensions for the Order.
  /// </summary>
  public ClientExtensions? ClientExtensionsModify { get; init; }

  /// <summary>
  /// The new Client Extensions for the Order’s Trade on fill.
  /// </summary>
  public ClientExtensions? TradeClientExtensionsModify { get; init; }
}
