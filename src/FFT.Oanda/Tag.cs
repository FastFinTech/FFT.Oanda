// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

/// <summary>
/// A tag associated with an entity.
/// </summary>
public sealed record Tag
{
  /// <summary>
  /// The type of the tag.
  /// </summary>
  public string Type { get; init; }

  /// <summary>
  /// The name of the tag.
  /// </summary>
  public string Name { get; init; }
}
