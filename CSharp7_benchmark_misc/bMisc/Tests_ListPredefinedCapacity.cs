// Not finished
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_ListPredefinedCapacity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Params(10, 100, 1000, 10000, 100000, 1000000)]
        public int Length { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public int tWithCapacity()
        {
            List<int> list = new(Length);
            for (int i = 0; i < Length; i++)
            {
                list.Add(i);
            }
            return list.Count;
        }

        [Benchmark]
        public int tDefault()
        {
            List<int> list = new();
            for (int i = 0; i < Length; i++)
            {
                list.Add(i);
            }
            return list.Count;
        }

    }
}