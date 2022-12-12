// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Collections.Immutable;
  using System.Globalization;
  using System.Text.Json.Serialization;
  using Microsoft.AspNetCore.WebUtilities;
  using static System.Math;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetTransactionIdRange(string,
  /// DateTime?, DateTime?, CancellationToken)"/> method.
  /// </summary>
  public sealed class GetTransactionIdRangeResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="GetTransactionIdRangeResponse"/> class.
    /// </summary>
    /// <remarks>Unlike most of the data models created in this project, this
    /// constructor contains parameters that are not also public properties, and
    /// processing is done to convert the json input parameters to useable
    /// property values.</remarks>
    [JsonConstructor]
    public GetTransactionIdRangeResponse(
      int count,
      DateTime from,
      DateTime to,
      string lastTransactionId,
      ImmutableList<string> pageLinks,
      int pageSize)
    {
      From = from;
      To = to;
      LastTransactionId = int.Parse(lastTransactionId, NumberStyles.Any, CultureInfo.InvariantCulture);
      FromTransactionId = int.MaxValue;
      ToTransactionId = int.MinValue;
      foreach (var url in pageLinks)
      {
        var query = new Uri(url).Query;
        var queryParts = QueryHelpers.ParseQuery(query);
        var thisFrom = int.Parse(queryParts["from"], NumberStyles.Any, CultureInfo.InvariantCulture);
        var thisTo = int.Parse(queryParts["to"], NumberStyles.Any, CultureInfo.InvariantCulture);
        FromTransactionId = Min(FromTransactionId, thisFrom);
        ToTransactionId = Max(ToTransactionId, thisTo);
      }
    }

    /// <summary>
    /// The starting time (inclusive) of the time range for the Transactions
    /// being queried.
    /// </summary>
    public DateTime From { get; init; }

    /// <summary>
    /// The ending time (inclusive) of the time range for the Transactions being
    /// queried.
    /// </summary>
    public DateTime To { get; init; }

    /// <summary>
    /// The id of the first transaction of the time range for the Transactions
    /// being queried.
    /// </summary>
    public int FromTransactionId { get; init; }

    /// <summary>
    /// The id of the last transaction of the time range for the Transactions
    /// being queried.
    /// </summary>
    public int ToTransactionId { get; init; }

    /// <summary>
    /// The id of the last transaction ever made on the Account.
    /// </summary>
    public int LastTransactionId { get; init; }
  }
}
