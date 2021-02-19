# FFT.SlottedTimers

[![Source code](https://img.shields.io/static/v1?style=flat&label=&message=Source%20Code&logo=read-the-docs&color=informational)](https://github.com/FastFinTech/FFT.SlottedTimers)
[![NuGet package](https://img.shields.io/nuget/v/FFT.COBS.svg)](https://nuget.org/packages/FFT.SlottedTimers)

`FFT.SlottedTimers` provides high-performance, allocation-free, inaccurate, asynchronous waits to replace use of the resource-intensive `Task.Delay(int milliseconds)` method provided by the .net framework.

You would use this tool if your application is scalable and has thousands of worker components performing concurrent waits.

```csharp
using FFT.SlottedTimers;

// Create a singleton timer instance with a resolution smaller than 
// the amount of time you would wait.
static readonly SlottedTimer _timer = new SlottedTimer(resolutionMS: 125);

// Perhaps thousands of these loops are running concurrently in your scalable application.
while(true)
{
  // NOOO!! Don't do this! It will kill your app!
  /*await Task.Delay(250).ConfigureAwait(false);*/

  // Use a high-performance, allocation-free, less accurate timer.
  await _timer.WaitAsync(milliseconds: 250).ConfigureAwait(false);
  // do some work or exit the loop
}
```

**Important!**

1. The `ValueTask` returned by `SlottedTimer.WaitAsync(...)`  must only be awaited once. Do not attempt to perform multiple or concurrent awaits on a single `ValueTask`. [Here's a complete explanation](https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/) 
1. Due to internal implementation, internal resources are not recycled until after the `ValueTask` has been awaited. Failing to await the `ValueTask` will result in memory leak and reduce the performance benefits, even if you have cancelled the wait with a `CancellationToken`.

### Full example

If your application is a server sending regular data updates to thousands of connected clients, you may be using some kind of wait to reduce the amount of data sent to each client. Here's an example of how you might do that with the `FFT.SlottedTimers.SlottedTimer`.

```csharp
/// <summary>
/// Your scalable data streaming server application may create THOUSANDS of
/// these objects at the same time. Each of the objects is performing regular
/// waits.
/// </summary>
private class ClientConnection : IDisposable
{
  private readonly SlottedTimer _timer;
  private readonly CancellationTokenSource _cancellation;
  private readonly CancellationToken _cancellationToken;

  private object? _data;

  // Reusing a singleton instance of the SlottedTimer. Important!
  public ClientConnection(SlottedTimer timer)
  {
    _timer = timer;
    _cancellation = new();
    _cancellationToken = _cancellation.Token;
    Task.Run(WorkAsync).ContinueWith(
      t =>
      {
        Debug.Fail($"{nameof(ClientConnection)}.{nameof(WorkAsync)} failed to complete.", t.Exception!.ToString());
      },
      TaskContinuationOptions.OnlyOnFaulted);
  }

  /// <summary>
  /// Called by external code an unlimited number of times per second.
  /// </summary>
  public void PostUpdate(object data)
  {
    // Set the most recent version of the data
    Interlocked.Exchange(ref _data, data);
  }

  public void Dispose()
  {
    // Signal cancellation so that the "WorkAsync" method can exit.
    _cancellation.Cancel();
    _cancellation.Dispose();
  }

  private async Task WorkAsync()
  {
    try
    {
      // This loop runs at a maximum of once per 250 milliseconds,
      // regardless of how fast the data is updated.
      while (true)
      {
        // NNOOOOOO!!!! Don't do this!! It will kill your application if
        // there are thousands of these connections!!!
        /*Task interval = Task.Delay(250, _cancellationToken);*/

        // Create a timer that starts when the work starts - but don't await it yet.
        // Note we don't really need the timer to be super-accurate.
        ValueTask interval = _timer.WaitAsync(250, _cancellationToken);

        // Check if there is an update available
        if (Interlocked.Exchange(ref _data, null) is object data)
        {
          // Yes, an update is available, now send the data to the client.
          // Oops, well, this IS DEMO code ... we imagine that data is being
          // sent over the wire here.
        }

        // Now await the timer we created earlier. The actual wait time will
        // vary, depending on how long it took to do the work above.
        await interval.ConfigureAwait(false);
      }
    }

    // This happens when the class is disposed, due to the
    // _cancellationToken used in the timer wait method.
    catch (OperationCanceledException) { }
  }
}
```

