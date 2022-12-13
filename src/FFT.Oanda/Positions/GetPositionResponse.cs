// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions
{
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetPosition(string, string, CancellationToken)"/> method.
  /// </summary>
  public sealed class GetPositionResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetPositionResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public GetPositionResponse(
      Position position,
      int lastTransactionID)
    {
      Position = position;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The requested Position.
    /// </summary>
    public Position Position { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionID { get; }
  }
}
