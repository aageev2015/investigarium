// conclusion: Is it unconsistant to estimate memory allocations in this way 

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock34_HashSetKeepElements
    {

        private class SomeAllocatableType(int[] bigData)
        {
            public int[] bigData { get; private set; } = bigData;
        }
        private static long fromMemory = default;
        private static readonly int testCount = 1000;

        public static void Do()
        {
            PrintMemoryChange("1.1. start");

            SomeMethod1();

            PrintMemoryChange("1.2. End");
        }

        private static void SomeMethod1()
        {
            PrintMemoryChange("2.1");

            var startingData = Enumerable.Range(1, testCount)
                .Select(i => new SomeAllocatableType(
                    Enumerable.Range(1, i).ToArray()
                    )).ToArray();

            Console.WriteLine(startingData.Length + startingData[1].bigData[1]);

            Console.WriteLine($"2.2. Expected allocation: {(long)testCount * (1 + testCount) * sizeof(int) / 2} ");

            PrintMemoryChange("2.3. After startingData");

            var hs = SomeMethod(startingData);

            PrintMemoryChange("2.4. after hashset method");

            Console.WriteLine(startingData.Length + startingData[0].bigData[0]);

            PrintMemoryChange("2.5. after last original data used");

            Console.WriteLine(hs.Count);

            PrintMemoryChange("2.6. after last hashset data used");
        }

        private static HashSet<T> SomeMethod<T>(IEnumerable<T> data)
        {
            PrintMemoryChange("3.1. start");
            HashSet<T> hs = new(data);
            PrintMemoryChange("3.2. After hashSet created");

            return hs;
        }

        private static void PrintMemoryChange(string title)
        {
            GC.Collect(1, GCCollectionMode.Forced);
            var toMemory = GC.GetTotalMemory(true);
            Thread.Sleep(200);

            Console.WriteLine($"{title}: {toMemory - fromMemory}");
            fromMemory = toMemory;
        }

    }
}
