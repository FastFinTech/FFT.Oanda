// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Thrown by the <see cref="OandaApiClient.CreateOrder(string, OrderRequest)"/> method when an order request is rejected.
  /// </summary>
  [Serializable]
  public class OrderRejectedException : Exception
  {
    internal OrderRejectedException(ErrorData orderRejection)
      : base($"Order was rejected. See '{nameof(RejectionData)}' property for more information.")
    {
      RejectionData = orderRejection;
    }

    /// <summary>
    /// Contains information about why an order request was rejected.
    /// </summary>
    public ErrorData RejectionData { get; }

    /// <summary>
    /// Contains information about why an order request was rejected.
    /// </summary>
    public sealed class ErrorData
    {
      /// <summary>
      /// Initializes a new instance of the <see
      /// cref="ErrorData"/> class.
      /// </summary>
      [JsonConstructor]
      public ErrorData(
        Transaction orderRejectTransaction,
        ImmutableList<string> relatedTransactionIds,
        string lastTransactionId,
        string? errorCode,
        string errorMessage)
      {
        OrderRejectTransaction = orderRejectTransaction;
        RelatedTransactionIds = relatedTransactionIds;
        LastTransactionId = lastTransactionId;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
      }

      /// <summary>
      /// The Transaction that rejected the creation of the Order as requested.
      /// The exact type of this transaction depends on the type of order that was
      /// requested.
      /// </summary>
      public Transaction OrderRejectTransaction { get; }

      /// <summary>
      /// The IDs of all Transactions that were created while satisfying the
      /// request.
      /// </summary>
      public ImmutableList<string> RelatedTransactionIds { get; }

      /// <summary>
      /// The ID of the most recent Transaction created for the Account.
      /// </summary>
      public string LastTransactionId { get; }

      /// <summary>
      /// The code of the error that has occurred. This field may not be returned
      /// for some errors.
      /// </summary>
      public string? ErrorCode { get; }

      /// <summary>
      /// The human-readable description of the error that has occurred.
      /// </summary>
      public string ErrorMessage { get; }
    }
  }

}
