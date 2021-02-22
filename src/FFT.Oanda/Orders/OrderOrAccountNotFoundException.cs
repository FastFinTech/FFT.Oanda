// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Thrown by the <see cref="OandaApiClient.ReplaceOrder(string, string,
  /// OrderRequest, string)"/> method when the specified account does not exist
  /// or the order to be replaced does not exist.
  /// </summary>
  [Serializable]
  public class OrderOrAccountNotFoundException : Exception
  {
    internal OrderOrAccountNotFoundException(ErrorData content)
      : base($"Operation failed because the account does not exist or the order to be replaced does not exist. See the '{nameof(Content)}' property for more information.")
    {
      Content = content;
    }

    /// <summary>
    /// Contains information about the order or account not found event and its
    /// related transactions.
    /// </summary>
    public ErrorData Content { get; }

    /// <summary>
    /// Contains information about the order or account not found event and its
    /// related transactions.
    /// </summary>
    public sealed class ErrorData
    {
      /// <summary>
      /// Initializes a new instance of the <see
      /// cref="ErrorData"/> class.
      /// </summary>
      [JsonConstructor]
      public ErrorData(
        OrderCancelRejectTransaction? orderCancelRejectTransaction,
        ImmutableList<string>? relatedTransactionIDs,
        string? lastTransactionID,
        string? errorCode,
        string errorMessage)
      {
        OrderCancelRejectTransaction = orderCancelRejectTransaction;
        RelatedTransactionIDs = relatedTransactionIDs;
        LastTransactionID = lastTransactionID;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
      }

      /// <summary>
      /// The Transaction that rejected the cancellation of the Order to be
      /// replaced. Only present if the Account exists.
      /// </summary>
      public OrderCancelRejectTransaction? OrderCancelRejectTransaction { get; }

      /// <summary>
      /// The Transaction that rejected the creation of the Order as requested.
      /// Only present if the Account exists. Instance type varies depending on
      /// the type of order that was requested.
      /// </summary>
      public Transaction? OrderRejectTransaction { get; }

      /// <summary>
      /// The IDs of all Transactions that were created while satisfying the
      /// request. Only present if the Account exists.
      /// </summary>
      public ImmutableList<string>? RelatedTransactionIDs { get; }

      /// <summary>
      /// The ID of the most recent Transaction created for the Account. Only
      /// present if the Account exists.
      /// </summary>
      public string? LastTransactionID { get; }

      /// <summary>
      /// The code of the error that has occurred. This field may not be
      /// returned for some errors.
      /// </summary>
      public string? ErrorCode { get; }

      /// <summary>
      /// The human-readable description of the error that has occurred.
      /// </summary>
      public string ErrorMessage { get; }
    }
  }
}
