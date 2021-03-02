// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  /// <summary>
  /// Used to specify the format that should be used for expressing times when
  /// transmitting json to and from the oanda api.
  /// </summary>
  public enum DateTimeFormat
  {
    /// <summary>
    /// “12345678.000000123” format.
    /// </summary>
    UNIX,

    /// <summary>
    /// “YYYY-MM-DDTHH:MM:SS.nnnnnnnnnZ”
    /// </summary>
    RFC3339,
  }
}
