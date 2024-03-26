using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace bMixNetVersions
{
    [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_GCAllocateArray
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Params(100, 1000, 10000)]
        public int Count { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public int[] tDefault()
        {
            return new int[Count];
        }

        [Benchmark]
        public int[] tGCAllocateArray()
        {
            return GC.AllocateArray<int>(Count);
        }

        [Benchmark]
        public int[] tGCAllocateUninitializedArray()
        {
            return GC.AllocateUninitializedArray<int>(Count);
        }

    }
}