// Not finished
using System.Runtime.CompilerServices;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_BenchMethodMustReturnProof
    // Hypothetical assertion: Benchmark method must return value to avoid compilation optimizations
    // Results: Not depends on on\off inline optimisation, All test shows same result.
    // Conclusion: Assertion is wrong.
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Params(10000)]
        public int InputValue { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {

        }


        [Benchmark(Baseline = true)]
        public void DoNoReturnNoInput()
        {
            int noResult = 0;
            int count = 10000;
            for (int i = 0; i < count; i++)
            {
                noResult += i;
            }
        }

        [Benchmark]
        public void DoNoReturn()
        {
            int noResult = 0;
            int count = this.InputValue;
            for (int i = 0; i < count; i++)
            {
                noResult += i;
            }
        }

        [Benchmark]
        public int Do()
        {
            int result = 0;
            int count = this.InputValue;
            for (int i = 0; i < count; i++)
            {
                result += i;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void DoNoReturnNoInputNoInline()
        {
            int noResult = 0;
            int count = 10000;
            for (int i = 0; i < count; i++)
            {
                noResult += i;
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void DoNoReturnNoInline()
        {
            int noResult = 0;
            int count = this.InputValue;
            for (int i = 0; i < count; i++)
            {
                noResult += i;
            }
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public int DoNoInline()
        {
            int result = 0;
            int count = this.InputValue;
            for (int i = 0; i < count; i++)
            {
                result += i;
            }
            return result;
        }



    }
}