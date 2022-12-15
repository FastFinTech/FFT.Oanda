// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// Contains the response from calls made to the <see
/// cref="OandaApiClient.GetPositionBook(string, DateTime?, CancellationToken)"/> method.
/// </summary>
public sealed record PositionBookResponse
{
  /// <summary>
  /// The instrument’s position book.
  /// </summary>
  public PositionBook PositionBook { get; init; }
}
