// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  /// <summary>
  /// Allows a client to attach a clientID, tag and comment to orders and trades
  /// in their account. Do not set, modify, or delete this field if your account
  /// is associated with MT4.
  /// </summary>
  public sealed class ClientExtensions
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientExtensions"/> class.
    /// </summary>
    [JsonConstructor]
    public ClientExtensions(string? id, string? tag, string? comment)
    {
      Id = id;
      Tag = tag;
      Comment = comment;
    }

    /// <summary>
    /// The Client ID of the order/trade.
    /// </summary>
    public string? Id { get; }

    /// <summary>
    /// A tag associated with the order/trade.
    /// </summary>
    public string? Tag { get; }

    /// <summary>
    /// A comment associated with the order/trade.
    /// </summary>
    public string? Comment { get; }
  }
}
