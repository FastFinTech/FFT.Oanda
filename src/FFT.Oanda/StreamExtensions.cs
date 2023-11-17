// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using FFT.IgnoreTasks;
using FFT.SlottedTimers;

internal static class StreamExtensions
{
  private const byte EOL = (byte)'\n'; // end of line, used to separate json messages.

  private static readonly SlottedTimer _timer = new(resolutionMS: 1000);

  public static async IAsyncEnumerable<ReadOnlySequence<byte>> ReadLines(this Stream stream, TimeSpan? messageTimeout, [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    var msgReceived = 0L;
    var reader = PipeReader.Create(stream);

    using var timeoutSignal = new CancellationTokenSource();
    using var combinedSignal = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutSignal.Token);
    var combinedSignalToken = combinedSignal.Token;

    if (messageTimeout.HasValue)
    {
      var messageTimeoutMS = (int)messageTimeout.Value.TotalMilliseconds;
      Task.Run(
        async () =>
        {
          while (true)
          {
            await _timer.WaitAsync(messageTimeoutMS, combinedSignalToken);
            if (Interlocked.CompareExchange(ref msgReceived, 0, 1) == 0)
              timeoutSignal.Cancel();
          }
        },
        CancellationToken.None).Ignore();
    }

    try
    {
      while (true)
      {
        var result = await reader.ReadAsync(combinedSignalToken);
        var buffer = result.Buffer;
        if (buffer.PositionOf(EOL) is SequencePosition position)
        {
          Interlocked.Exchange(ref msgReceived, 1);
          var slice = buffer.Slice(0, position);
          yield return slice;
          reader.AdvanceTo(buffer.GetPosition(1, position));
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

      if (timeoutSignal.IsCancellationRequested && !cancellationToken.IsCancellationRequested)
      {
        throw new TimeoutException($"Timeout waiting for heartbeat message. Timeout was set at '{(int)messageTimeout!.Value.TotalMilliseconds}' ms.");
      }
    }
  }
}
