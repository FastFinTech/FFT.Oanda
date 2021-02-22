// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// An exception that is thrown when the Oanda api rejects the configuration
  /// requested in the <see cref="OandaApiClient.SetAccountConfiguration(string,
  /// AccountConfiguration)"/> method.
  /// </summary>
  public sealed class AccountConfigurationRejectedException : Exception
  {
    internal AccountConfigurationRejectedException(AccountConfigurationRejection rejectionData)
        : base($"Account configuration request was rejected. See {nameof(RejectionData)} for details.")
    {
      RejectionData = rejectionData;
    }

    /// <summary>
    /// Data that explains why the account configuration request was denied.
    /// </summary>
    public AccountConfigurationRejection RejectionData { get; }

    /// <summary>
    /// Contains data returned when the oanda api rejects an account
    /// configuration response.
    /// </summary>
    public sealed class AccountConfigurationRejection
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="RejectionData"/> class.
      /// </summary>
      [JsonConstructor]
      public AccountConfigurationRejection(
        ClientConfigureRejectTransaction clientConfigureRejectTransaction,
        string lastTransactionID,
        string? errorCode,
        string errorMessage)
      {
        ClientConfigureRejectTransaction = clientConfigureRejectTransaction;
        LastTransactionID = lastTransactionID;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
      }

      /// <summary>
      /// The transaction that rejects the configuration of the Account.
      /// </summary>
      public ClientConfigureRejectTransaction ClientConfigureRejectTransaction { get; }

      /// <summary>
      /// The ID of the last Transaction created for the Account.
      /// </summary>
      public string LastTransactionID { get; }

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
