using Microsoft.Extensions.Caching.Memory;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock20_MemoryCache
    {

        public static async void Do()
        {
            using IMemoryCache memCache = new MemoryCache(new MemoryCacheOptions { });
            /*using var cancelSource = new CancellationTokenSource();
            var cancelToken = cancelSource.Token;

            Lazy<Task<int>> lazyVal = new(async () =>
            {
                await Task.Delay(100, cancelToken);
                return 5;
            });
            
            var val = await lazyVal.Value;
            */

            memCache.Set(66, new Lazy<int>(() => 5));
            Console.WriteLine(memCache.TryGetValue(66, out Lazy<int>? t1));
            Console.WriteLine(t1?.GetType().FullName);
            Console.WriteLine(memCache.TryGetValue(66, out int? t2));
            Console.WriteLine(t2?.GetType().FullName);

            Console.Out.WriteLineAsync("-------");

            memCache.Set(66, 55,
                new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(2)));

            Thread.Sleep(1800);
            {
                Console.Out.WriteLineAsync($"   {1}");
                Console.WriteLine(memCache.TryGetValue(66, out Lazy<int>? t3));
                Console.WriteLine(t3?.GetType().FullName);
                Console.WriteLine(memCache.TryGetValue(66, out int? t4));
                Console.WriteLine(t4?.GetType().FullName);
            }
            Thread.Sleep(2100);
            {
                Console.Out.WriteLineAsync($"   {2}");
                Console.WriteLine(memCache.TryGetValue(66, out Lazy<int>? t3));
                Console.WriteLine(t3?.GetType().FullName);
                Console.WriteLine(memCache.TryGetValue(66, out int? t4));
                Console.WriteLine(t4?.GetType().FullName);
            }
        }
    }
}

