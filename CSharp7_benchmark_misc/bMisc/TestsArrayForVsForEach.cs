// in process
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class TestsArrayForVsForEach
    {
        [Params(2, 8, 64, 256, 1024, 65536)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int ArrayLength;
        private int[] array;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
            array = Enumerable.Range(0, ArrayLength - 1).ToArray();
        }

        #region Benchmarks

        [Benchmark(Baseline = true)]
        public int tSum_NormalFor()
        {
            int sum = 0;
            var len = this.array.Length;
            for (int i = 0; i < len; i++)
            {
                sum += this.array[i];
            }
            return sum;
        }

        [Benchmark]
        public int tSum_ForEachWithClosure()
        {
            int sum = 0;
            Array.ForEach(this.array, i => sum += this.array[i]);
            return sum;
        }


        #endregion

    }
}