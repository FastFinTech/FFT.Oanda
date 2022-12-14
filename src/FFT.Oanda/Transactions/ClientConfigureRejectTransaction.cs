// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A ClientConfigureRejectTransaction represents the reject of configuration
/// of an Account by a client.
/// </summary>
public sealed record ClientConfigureRejectTransaction : Transaction
{
  /// <summary>
  /// The client-provided alias for the Account.
  /// </summary>
  public string? Alias { get; init; }

  /// <summary>
  /// The margin rate override for the Account.
  /// </summary>
  public decimal MarginRate { get; init; }

  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
