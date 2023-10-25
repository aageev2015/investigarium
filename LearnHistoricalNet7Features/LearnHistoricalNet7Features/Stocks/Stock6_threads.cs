namespace LearnHistoricalNet7_8Features.Stocks
{
    public class Stock6_threads
    {

        public async static Task Do()
        {
            var random = Random.Shared;

            async IAsyncEnumerable<int[]> SimStreamAsync(int value = 0)
            {
                Console.WriteLine($"SimStreamAsync({value})");
                while (true)
                {
                    await Task.Delay(random.Next(5, 20));
                    Console.WriteLine($"""yield {value}                   {Thread.CurrentThread.ManagedThreadId}\{ThreadPool.ThreadCount}""");
                    yield return new int[] { ++value, ++value, ++value, ++value, ++value };
                    Console.WriteLine($"""yielded {value}                   {Thread.CurrentThread.ManagedThreadId}\{ThreadPool.ThreadCount}""");
                }
            }

            async ValueTask process(int[] numbers, CancellationToken token)
            {

                await Task.Delay(random.Next(500, 1000));
                Console.WriteLine($"""{numbers.Last()}        {Thread.CurrentThread.ManagedThreadId}\{ThreadPool.ThreadCount}""");
            }


            Console.WriteLine("start");
            var tasks = SimStreamAsync();
            await Parallel.ForEachAsync(tasks,
                new ParallelOptions { MaxDegreeOfParallelism = 10 }, process);
            Console.WriteLine("done");
        }

    }
}

