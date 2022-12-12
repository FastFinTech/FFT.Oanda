// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Collections;
  using System.Collections.Immutable;
  using System.Globalization;
  using System.Linq;
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;
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
      int lastTransactionId,
      ImmutableList<string> pages,
      int pageSize)
    {
      Count = count;
      From = from;
      To = to;
      LastTransactionId = lastTransactionId;
      PageSize = pageSize;
      Pages = pages;
    }

    /// <summary>
    /// The number of Transactions that are contained in the pages returned.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// The starting time (inclusive) of the time range for the Transactions
    /// being queried.
    /// </summary>
    public DateTime From { get; }

    /// <summary>
    /// The ending time (inclusive) of the time range for the Transactions being
    /// queried.
    /// </summary>
    public DateTime To { get; }

    /// <summary>
    /// The list of URLs that represent idrange queries providing the data for
    /// each page in the query results.
    /// </summary>
    public ImmutableList<string> Pages { get; init; }

    /// <summary>
    /// The id of the last transaction ever made on the Account.
    /// </summary>
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionId { get; init; }

    /// <summary>
    /// The pageSize provided in the request.
    /// </summary>
    public int PageSize { get; init; }

    public IEnumerable<(int FromId, int ToId)> GetPages()
    {
      return GetPages().OrderBy(x => x.FromId);
      IEnumerable<(int FromId, int ToId)> GetPages()
      {
        if (Pages.Count == 0) yield break;
        foreach (var url in Pages)
        {
          var query = new Uri(url).Query;
          var queryParts = QueryHelpers.ParseQuery(query);
          var thisFrom = int.Parse(queryParts["from"], NumberStyles.Any, InvariantCulture);
          var thisTo = int.Parse(queryParts["to"], NumberStyles.Any, InvariantCulture);
          yield return (thisFrom, thisTo);
        }
      }
    }
  }
}
