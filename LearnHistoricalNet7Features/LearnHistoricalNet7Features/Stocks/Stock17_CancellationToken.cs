using System.Diagnostics;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock17_CancellationToken
    {

        public static void Do()
        {
            using var cancelSource = new CancellationTokenSource(100);
            var cancelToken = cancelSource.Token;

            var sw = new Stopwatch();
            sw.Start();
            var t = Task.Run(async () =>
            {
                Console.WriteLine($"Task start {sw.ElapsedMilliseconds}");
                try
                {
                    await Task.Delay(1000, cancelToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}. {sw.ElapsedMilliseconds}");
                    if (!cancelToken.IsCancellationRequested) throw;
                }
                Console.WriteLine($"Task end {sw.ElapsedMilliseconds}");
            });

            var t2 = Task.Run(() =>
            {
                Console.WriteLine($"Task 2 start {sw.ElapsedMilliseconds}");
                while (!cancelToken.IsCancellationRequested) ;
                Console.WriteLine($"Task 2 end {sw.ElapsedMilliseconds}");
            });

            Task.WaitAll([t, t2]);
            sw.Stop();

            Console.WriteLine($"{sw.ElapsedMilliseconds}");
        }
    }
}

