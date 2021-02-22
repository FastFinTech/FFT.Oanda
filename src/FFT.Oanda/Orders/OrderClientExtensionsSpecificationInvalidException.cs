// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Thrown by the <see cref="OandaApiClient.SetOrderClientExtensions(string,
  /// string, ClientExtensions?, ClientExtensions?)"/> method when the request
  /// is rejected due to invalid order client extensions.
  /// </summary>
  [Serializable]
  public class OrderClientExtensionsSpecificationInvalidException : Exception
  {
    internal OrderClientExtensionsSpecificationInvalidException(ErrorData content)
      : base($"The order client extensions specification was invalid. See the '{nameof(Content)}' property for more information.")
    {
      Content = content;
    }

    /// <summary>
    /// Contains information related to a rejection of invalid order client extensions.
    /// </summary>
    public ErrorData Content { get; }

    /// <summary>
    /// Contains information related to a rejection of invalid order client extensions.
    /// </summary>
    public sealed class ErrorData
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="ErrorData"/> class.
      /// </summary>
      [JsonConstructor]
      public ErrorData(
        OrderClientExtensionsModifyRejectTransaction orderClientExtensionsModifyRejectTransaction,
        string lastTransactionID,
        ImmutableList<string> relatedTransactionIDs,
        string? errorCode,
        string errorMessage)
      {
        OrderClientExtensionsModifyRejectTransaction = orderClientExtensionsModifyRejectTransaction;
        LastTransactionID = lastTransactionID;
        RelatedTransactionIDs = relatedTransactionIDs;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
      }

      /// <summary>
      /// The Transaction that rejected the modification of the Client
      /// Extensions for the Order.
      /// </summary>
      public OrderClientExtensionsModifyRejectTransaction OrderClientExtensionsModifyRejectTransaction { get; }

      /// <summary>
      /// The ID of the most recent Transaction created for the Account.
      /// </summary>
      public string LastTransactionID { get; }

      /// <summary>
      /// The IDs of all Transactions that were created while satisfying the
      /// request.
      /// </summary>
      public ImmutableList<string> RelatedTransactionIDs { get; }

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
