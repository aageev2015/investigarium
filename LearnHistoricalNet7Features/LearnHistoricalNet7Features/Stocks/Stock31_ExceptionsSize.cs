using System.Runtime.CompilerServices;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock31_ExceptionsSize
    {
        private static readonly int ItemsCount = 10000;

        public static void Do()
        {
            universalTest((_) => new Exception());
            universalTest((_) => new Exception("Some constant\\hardocded\\inline and looks like very long error text message"));
            universalTest((key) => new Exception($"Some dynamically collected error text message key={key}"));
        }

        private static void universalTest<T>(Func<int, T> newEntity, [CallerArgumentExpression("newEntity")] string newEntityExpression = "")
        {
            MemSizeMeasurer measurer = new(true);
            var exceptions = new T[ItemsCount];

            measurer.Start();
            for (int i = 0; i < ItemsCount; i++)
            {
                exceptions[i] = newEntity(i);
            }
            measurer.Stop();

            Console.WriteLine($"{newEntityExpression}:\n\ttotal = {measurer.AggregatedSize} bytes\n\tper item = {measurer.AggregatedSize / ItemsCount} bytes");
        }

        private class MemSizeMeasurer(bool forceFullCollection = false)
        {
            public long AggregatedSize { get; private set; } = 0;
            private long fromSize = -1;
            private bool forceFullCollection = forceFullCollection;

            public void Start()
            {
                fromSize = GC.GetTotalMemory(forceFullCollection);
            }

            public bool Stop()
            {
                if (fromSize < 0)
                {
                    return false;
                }
                long toSize = GC.GetTotalMemory(forceFullCollection);
                AggregatedSize += toSize - fromSize;
                fromSize = 0; ;

                return true;
            }

            public void Reset()
            {
                Stop();
                AggregatedSize = 0;
                Start();
            }


        }

    }
}
