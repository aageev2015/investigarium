// Parallel.Invoke vs Task.WhenAll. Investigate switch speed for CPU bound work only
// Motivation: https://www.linkedin.com/posts/iman-safari_taskwhenall-vs-parallelinvoke-ugcPost-7178023365268365313-mG0O/
using System.Runtime.CompilerServices;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_WhenAllVsParallelInvoke
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Params(100, 10_000, 1000_000_000)]
        public long Cycles { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public async Task<int> tWhenAll()
        {
            await Task.WhenAll(IOTask1(), IOTask2());
            return 0;
        }

        [Benchmark]
        public int tParallelInvoke()
        {
            Parallel.Invoke(CPUWork1, CPUWork2);
            return 0;
        }

        private async Task IOTask1()
        {
            await Task.Run(() =>
            {
                CPUWork1();
            });
        }

        private async Task IOTask2()
        {
            await Task.Run(() =>
            {
                CPUWork2();
            });
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void CPUWork1()
        {
            CPUWorkCommon();
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void CPUWork2()
        {
            CPUWorkCommon();
        }

        private int CPUWorkCommon()
        {
            int result = 0;

            for (long i = 0; i < Cycles; i++)
            {
                result += unchecked((int)(i * (i % 2 * 2 - 1)));
            }

            return result;
        }

    }
}