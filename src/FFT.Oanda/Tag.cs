// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Text.Json.Serialization;

/// <summary>
/// A tag associated with an entity.
/// </summary>
public sealed class Tag
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Tag"/> class.
  /// </summary>
  [JsonConstructor]
  public Tag(
    string type,
    string name)
  {
    Type = type;
    Name = name;
  }

  /// <summary>
  /// The type of the tag.
  /// </summary>
  public string Type { get; }

  /// <summary>
  /// The name of the tag.
  /// </summary>
  public string Name { get; }
}
