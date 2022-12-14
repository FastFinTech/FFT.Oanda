// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// Contains the response from calls made to the <see
/// cref="OandaApiClient.GetPositionBook(string, DateTime?, CancellationToken)"/> method.
/// </summary>
public sealed class PositionBookResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="PositionBookResponse"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public PositionBookResponse(
    PositionBook positionBook)
  {
    PositionBook = positionBook;
  }

  /// <summary>
  /// The instrument’s position book.
  /// </summary>
  public PositionBook PositionBook { get; }
}
