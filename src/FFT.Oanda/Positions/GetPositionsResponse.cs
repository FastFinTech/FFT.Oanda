// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetPositions(string)"/> method.
  /// </summary>
  public sealed class GetPositionsResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetPositionsResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public GetPositionsResponse(
      ImmutableList<Position> positions,
      string lastTransactionID)
    {
      Positions = positions;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The list of Account Positions.
    /// </summary>
    public ImmutableList<Position> Positions { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionID { get; }
  }
}
