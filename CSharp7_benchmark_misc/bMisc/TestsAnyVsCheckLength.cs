// in process
using System.Runtime.CompilerServices;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class TestsAnyVsCheckLength
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private int[] array;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
            array = Enumerable.Range(0, 100).ToArray();
        }

        #region Benchmarks

        [Benchmark(Baseline = true)]
        public bool tAny()
        {
            return array.Any();
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public bool tLength()
        {
            return array.Length != 0;
        }


        #endregion

    }
}