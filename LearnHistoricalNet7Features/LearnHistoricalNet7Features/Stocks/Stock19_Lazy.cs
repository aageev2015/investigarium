using System.Diagnostics;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock19_Lazy
    {

        private static Stopwatch stopwatch = new Stopwatch();

        public static async Task Do()
        {
            stopwatch.Start();

            foreach (var lazyThreadSafetyMode in Enum.GetValues<LazyThreadSafetyMode>())
            {
                LazyInt_ExecutionAndPublication(lazyThreadSafetyMode);
                await LazyIntAsync_ExecutionAndPublication(lazyThreadSafetyMode);
            }

            //Lazy<Task<int>> lazyTask = new(async (int v) => { await Task.Delay(100); return v * 5; });

            uint val = 2;
            var retVal = Interlocked.CompareExchange(ref val, 1, 2);
            Console.WriteLine($"val = {val}, oldVal = {retVal}");

            stopwatch.Stop();
        }

        private static void LazyInt_ExecutionAndPublication(LazyThreadSafetyMode lazyThreadSafetyMode)
        {
            Console.WriteLine();
            Console.WriteLine($"-------  Lazy<int>  {lazyThreadSafetyMode}  -----");

            var lazyVal = new Lazy<int>(() =>
            {
                Console.WriteLine($"Start generation. In thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}");
                Thread.Sleep(500);
                Console.WriteLine($"End generation. In thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}");
                return Thread.CurrentThread.ManagedThreadId;
            }, lazyThreadSafetyMode);

            Parallel.ForEach(Enumerable.Range(1, 10), (v) =>
            {
                Console.WriteLine($"Index: {v}. Start in thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}");
                try
                {
                    var val = lazyVal.Value;
                    Console.WriteLine($"Index: {v}. End. in thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}. Value: {val}");
                }
                catch (Exception ex)
                {
                    LogException(v, ex);
                }
            });
        }

        private static async Task LazyIntAsync_ExecutionAndPublication(LazyThreadSafetyMode lazyThreadSafetyMode)
        {
            Console.WriteLine();
            Console.WriteLine($"-------  Lazy<Task<int>>  {lazyThreadSafetyMode}  -----");

            var lazyVal = new Lazy<Task<int>>(async () =>
            {
                Console.WriteLine($"Start generation. In thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}");
                await Task.Delay(500);
                //Thread.Sleep(500);
                Console.WriteLine($"End generation. In thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}");
                //return Task.FromResult(Thread.CurrentThread.ManagedThreadId);
                return Thread.CurrentThread.ManagedThreadId;
            }, lazyThreadSafetyMode);

            await Parallel.ForEachAsync(Enumerable.Range(1, 10), async (v, _) =>
            {
                Console.WriteLine($"Index: {v}. Start in thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}");
                try
                {
                    var val = await lazyVal.Value.ConfigureAwait(false);
                    Console.WriteLine($"Index: {v}. End. in thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}. Value: {val}");
                }
                catch (Exception ex)
                {
                    LogException(v, ex);
                }
            });
        }

        private static void LogException(int index, Exception ex)
        {
            Console.WriteLine($"Index: {index}. Exaption. in  thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {stopwatch.ElapsedMilliseconds}. {ex.GetType().Name}, {ex.Message}");
        }
    }
}

