using System.Collections.Concurrent;
using System.Diagnostics;

namespace Channels
{
    public sealed class SimpleChannel<T>
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>(); // stores our data
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0); // for limiting access/coordinate communciation between producer/consumer

        public void Write(T value)
        {
            _queue.Enqueue(value); // store the data
            _semaphore.Release(); // notify any consumers that more data is available
        }

        public async ValueTask<T> ReadAsync(CancellationToken cancellationToken = default)
        {
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false); // wait
            bool gotOne = _queue.TryDequeue(out T item); // retrieve the data
            Debug.Assert(gotOne);
            return item;
        }

    }
}