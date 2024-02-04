using Microsoft.Extensions.Caching.Memory;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock21_MemoryCache2
    {
        private class CachedItem
        {
            public int Value { get; set; }
            public CachedItem(int v)
            {
                Value = v;
                Console.WriteLine($"Constructed in {Thread.CurrentThread.ManagedThreadId}");
            }
        }

        public static void Do()
        {
            DoAsync().Wait();
        }

        private static async Task DoAsync()
        {
            using IMemoryCache memCache = new MemoryCache(new MemoryCacheOptions { });
            await Console.Out.WriteLineAsync("Start");
            var results = new CachedItem?[10];
            try
            {
                await Parallel.ForAsync(0, 10, async (index, ct) =>
                {
                    var val = memCache.GetOrCreate(55, cacheEntry =>
                    {
                        Console.WriteLine($"create {index}. {Thread.CurrentThread.ManagedThreadId}");
                        cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(10);
                        return new Lazy(() => new CachedItem(index * 10));
                    });
                    results[index] = val;
                    await Console.Out.WriteLineAsync($"Read {val} {index}. {Thread.CurrentThread.ManagedThreadId}");
                });
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            await Console.Out.WriteLineAsync("DONE");
        }
    }
}

