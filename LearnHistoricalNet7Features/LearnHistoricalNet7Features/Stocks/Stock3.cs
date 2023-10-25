namespace LearnHistoricalNet7_8Features.Stocks
{
    public class Stock3
    {
        private bool _loop = true;

        public static void Do()
        {
            var obj = new Stock3();
            Console.WriteLine("start");
            // Set _loop to false on another thread
            new Thread(() => { obj._loop = false; }).Start();

            // Poll the _loop field until it is set to false
            while (obj._loop == true) ;
            Console.WriteLine("done");
            // The loop above will never terminate!
        }

    }
}

