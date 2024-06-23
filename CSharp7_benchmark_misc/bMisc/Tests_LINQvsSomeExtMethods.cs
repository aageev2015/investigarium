// Not finished
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_LINQvsSomeExtMethods
    {
        private record TestRecord(int Id, string Name);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        List<TestRecord> commonData;
        List<string> testData;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
            commonData = [
                new TestRecord(1, "Jonson"),
                new TestRecord(2, "Baby"),
                new TestRecord(3, "Richard"),
                new TestRecord(4, "Todor"),
                new TestRecord(5, "Alice"),
                new TestRecord(6, "Troll"),
                new TestRecord(7, "Zorro"),
                new TestRecord(8, "Rabbit"),
                new TestRecord(9, "Keyboard"),
                new TestRecord(10, "Tron"),
                new TestRecord(11, "Zodd"),
                new TestRecord(12, "Astalavista"),
                new TestRecord(13, "data 1"),
                new TestRecord(14, "data 3"),
                new TestRecord(15, "data 4"),
                new TestRecord(16, "data 5"),
                new TestRecord(17, "data 6"),
                new TestRecord(18, "SomethingLast"),
            ];

            testData = ["Jonson", "Troll", " miss 1", " miss 2 ", "Astalavista", " miss 3", "SomethingLast"];
        }


        [Benchmark(Baseline = true)]
        public int tExceptBy_LINQ()
        {
            var result = (from r in commonData
                          where !testData.Contains(r.Name)
                          select r)
                          .ToList();

            return result.Count();
        }

        [Benchmark]
        public int tExceptBy()
        {
            var result = commonData
                .ExceptBy(testData, r => r.Name)
                .ToList();

            return result.Count();
        }

        [Benchmark]
        public int tIntersectBy_LINQ()
        {
            var result = (from r in commonData
                          where testData.Contains(r.Name)
                          select r)
                          .ToList();

            return result.Count();
        }

        [Benchmark]
        public int tIntersectBy()
        {
            var result = commonData
                .IntersectBy(testData, r => r.Name)
                .ToList();

            return result.Count();
        }

    }
}