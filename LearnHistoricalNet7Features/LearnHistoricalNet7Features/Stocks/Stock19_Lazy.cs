using System.Diagnostics;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock19_Lazy
    {

        public static void Do()
        {
            var st = new Stopwatch();
            st.Start();

            var lazyVal = new Lazy<int>(() =>
            {
                Console.WriteLine($"Start generation. In thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {st.ElapsedMilliseconds}");
                Thread.Sleep(500);
                Console.WriteLine($"End generation. In thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {st.ElapsedMilliseconds}");
                return Thread.CurrentThread.ManagedThreadId;
            }, LazyThreadSafetyMode.ExecutionAndPublication);



            Parallel.ForEach(Enumerable.Range(1, 10), (v) =>
            {
                Console.WriteLine($"Index: {v}. Start in thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {st.ElapsedMilliseconds}");
                var val = lazyVal.Value;
                Console.WriteLine($"Index: {v}. End. in thread {Thread.CurrentThread.ManagedThreadId}. Elapsed: {st.ElapsedMilliseconds}. Value: {val}");
            });

            //Lazy<Task<int>> lazyTask = new(async (int v) => { await Task.Delay(100); return v * 5; });

            uint val = 2;
            var retVal = Interlocked.CompareExchange(ref val, 1, 2);
            Console.WriteLine($"val = {val}, oldVal = {retVal}");
            st.Stop();
        }
    }
}

