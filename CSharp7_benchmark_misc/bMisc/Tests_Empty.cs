// Not finished
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_Empty
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public long tTest1()
        {
            return 0;
        }

    }
}