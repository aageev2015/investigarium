namespace LearnHistoricalNet7_8Features.Stocks
{
    public class Stock4_threads
    {

        private static async Task<int> Async1()
        {
            return 1;
        }

        public static async void Do()
        {
            Task<int> valTask = Async1();
            var v1 = await valTask;
            await Console.Out.WriteLineAsync($"{v1}");
            var v2 = await valTask;
            await Console.Out.WriteLineAsync($"{v2}");
        }

        public static void Do2()
        {
            Console.WriteLine("step 1");
            Task t = new(() =>
            {
                Console.WriteLine("hello1");

            });
            t.Start();
            Console.WriteLine("step 2");
            t.Wait();
            Console.WriteLine("step 3");
        }

        public static void Do1()
        {
            var pool = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() => Console.Write(i));
                thread.Start();
                pool[i] = thread;
            }
            for (var i = 0; i < pool.Length; i++)
            {
                pool[i].Join();
            }

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                int tmp = i;
                var thread = new Thread(() => Console.Write(tmp));
                thread.Start();
            }
        }

    }
}

