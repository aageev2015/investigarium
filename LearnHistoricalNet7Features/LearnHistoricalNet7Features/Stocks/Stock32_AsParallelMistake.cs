using System.Diagnostics;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock32_AsParallelMistake
    {
        public static void Do()
        {
            var items = Enumerable.Range(0, 10)
                .Select((i) => { Thread.Sleep(1000); return i * 2; });

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in items) ;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            var items2 = Enumerable.Range(0, 10)
                .AsParallel()
                .Select((i) => { Thread.Sleep(1000); return i * 2; });
            sw.Reset();
            sw.Start();
            foreach (var item in items2) ;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            var items3 = Enumerable.Range(0, 10)
                .Select((i) => { Thread.Sleep(1000); return i * 2; })
                .AsParallel();
            sw.Reset();
            sw.Start();
            foreach (var item in items3) ;
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

        }

    }
}
