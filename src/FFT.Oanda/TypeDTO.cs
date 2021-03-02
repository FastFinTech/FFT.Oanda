// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  /// <summary>
  /// Used internally by json converters when deserializing objects, to read the
  /// "type" property of a json document in order to determine the correct type
  /// for deserialization.
  /// </summary>
  internal struct TypeDTO
  {
    /// <summary>
    /// The "type" property found on the json document.
    /// </summary>
    public string Type { get; set; }
  }
}
