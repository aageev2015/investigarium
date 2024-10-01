namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock46_yieldReturn
    {

        public static void Do()
        {
            var val1 = items();
            var val2 = 0;//items();
            var val3 = items().Count();
            var val4 = items().Count();
            Console.WriteLine($"----------\n{val1}\n{val2}\n{val3}\n{val4}");
        }

        public static IEnumerable<int> items()
        {
            Console.WriteLine("items start");
            yield return 4;
            yield return 5;
            Console.WriteLine("items end");
        }

    }
}
