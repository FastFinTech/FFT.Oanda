// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Diagnostics;
using System.Net;

/// <summary>
/// Thrown when an api request is denied. Check the <see cref="StatusCode"/>
/// and <see cref="ResponseContent"/> properties for information returned by the api.
/// </summary>
public class RequestFailedException : Exception
{
  internal RequestFailedException(HttpStatusCode statusCode, string responseContent)
  {
    StatusCode = statusCode;
    ResponseContent = responseContent;
  }

  /// <summary>
  /// The status code contained in the response that denied the request.
  /// </summary>
  public HttpStatusCode StatusCode { get; }

  /// <summary>
  /// The deserialized json content of the reponse that denied the request.
  /// </summary>
  public string ResponseContent { get; }

  internal static async Task ThrowIfNecessary(HttpResponseMessage response, CancellationToken cancellationToken = default)
  {
    if (response.IsSuccessStatusCode)
      return;

    RequestFailedException exception;
    try
    {
      var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      exception = new RequestFailedException(response.StatusCode, responseContent);
    }
    catch (Exception x)
    {
      Debug.Fail("Failed to parse json document from api error reponse.", x.ToString());
      throw;
    }

    throw exception;
  }
}
