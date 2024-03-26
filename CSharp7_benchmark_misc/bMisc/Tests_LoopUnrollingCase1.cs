// Unrolling loops optimisation. Strange results
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_LoopUnrollingCase1
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private int[] Array;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [GlobalSetup]
        public void GlobalSetup()
        {
            Array = Enumerable.Range(0, 10000).ToArray();
        }


        [Benchmark(Baseline = true)]
        public long tTestStandart()
        {
            var sum = 0;
            for (var i = 0; i < Array.Length; i++)
            {
                sum += Array[i];
            }
            return sum;
        }

        [Benchmark]
        public long tTestStandartCached()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i++)
            {
                sum += Array[i];
            }
            return sum;
        }


        [Benchmark]
        public long tTestUnrollX2Cached()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i += 2)
            {
                sum += Array[i];
                sum += Array[i + 1];
            }
            return sum;
        }

        [Benchmark]
        public long tTestUnrollX4Cached()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i += 4)
            {
                sum += Array[i];
                sum += Array[i + 1];
                sum += Array[i + 2];
                sum += Array[i + 3];
            }
            return sum;
        }

        [Benchmark]
        public long tTestUnrollX8Cached()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i += 8)
            {
                sum += Array[i];
                sum += Array[i + 1];
                sum += Array[i + 2];
                sum += Array[i + 3];
                sum += Array[i + 4];
                sum += Array[i + 5];
                sum += Array[i + 6];
                sum += Array[i + 7];
            }
            return sum;
        }

        [Benchmark]
        public long tTestUnrollX16Cached()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i += 16)
            {
                sum += Array[i];
                sum += Array[i + 1];
                sum += Array[i + 2];
                sum += Array[i + 3];
                sum += Array[i + 4];
                sum += Array[i + 5];
                sum += Array[i + 6];
                sum += Array[i + 7];
                sum += Array[i + 8];
                sum += Array[i + 9];
                sum += Array[i + 10];
                sum += Array[i + 11];
                sum += Array[i + 12];
                sum += Array[i + 14];
                sum += Array[i + 15];
            }
            return sum;
        }

        [Benchmark]
        public long tTestStandartCachedPlusAndMult2()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i++)
            {
                sum += Array[i] * 2;
            }
            return sum;
        }

        [Benchmark]
        public long tTestStandartCachedPlusAndMult11()
        {
            var sum = 0;
            var len = Array.Length;
            for (var i = 0; i < len; i++)
            {
                sum += Array[i] * 11;
            }
            return sum;
        }

    }
}