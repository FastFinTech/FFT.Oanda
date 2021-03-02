// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Diagnostics;
  using System.Net;
  using System.Net.Http;
  using System.Text.Json;
  using System.Threading.Tasks;

  /// <summary>
  /// Thrown when an api request is denied. Check the <see cref="StatusCode"/>
  /// and <see cref="Content"/> properties for information returned by the api.
  /// </summary>
  public class RequestFailedException : Exception
  {
    internal RequestFailedException(HttpStatusCode statusCode, JsonElement content)
    {
      StatusCode = statusCode;
      Content = content;
    }

    /// <summary>
    /// The status code contained in the response that denied the request.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// The deserialized json content of the reponse that denied the request.
    /// </summary>
    public JsonElement Content { get; }

    internal static async Task ThrowIfNecessary(HttpResponseMessage response)
    {
      if (response.IsSuccessStatusCode)
        return;

      RequestFailedException exception;
      try
      {
        using var stream = await response.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(stream);
        exception = new RequestFailedException(response.StatusCode, doc.RootElement.Clone());
      }
      catch (Exception x)
      {
        // This happens when the api returns non json or invalid json content
        // in its error reponse. Right now, we assume this will never happen.
        // We need to become aware if it ever does happen, and handle it
        // accordingly here.
        Debug.Fail("Failed to parse json document from api error reponse.", x.ToString());
        throw;
      }

      throw exception;
    }
  }
}
