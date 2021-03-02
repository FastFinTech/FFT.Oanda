// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Buffers;
  using System.Collections.Generic;
  using System.IO;
  using System.IO.Pipelines;
  using System.Runtime.CompilerServices;
  using System.Threading;

  internal static class StreamExtensions
  {
    private const byte EOL = (byte)'\n'; // end of line, used to separate json messages.

    public static async IAsyncEnumerable<ReadOnlySequence<byte>> ReadLines(this Stream stream, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      var reader = PipeReader.Create(stream);
      try
      {
        while (true)
        {
          var result = await reader.ReadAsync(cancellationToken);
          var buffer = result.Buffer;
          var position = buffer.PositionOf(EOL);
          if (position.HasValue)
          {
            var slice = buffer.Slice(0, position.Value);
            yield return slice;
            reader.AdvanceTo(position.Value);
          }
          else
          {
            reader.AdvanceTo(buffer.Start, buffer.End);
            if (result.IsCompleted)
              yield break;
          }
        }
      }
      finally
      {
        reader.Complete();
      }
    }
  }
}
