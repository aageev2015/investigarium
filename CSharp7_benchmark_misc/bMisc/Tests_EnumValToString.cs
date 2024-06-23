// Not finished
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_EnumValToString
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private enum TestingEnum
        {
            Val1, Val2, Val3, Val4
        }

        [GlobalSetup]
        public void GlobalSetup()
        {

        }

        [Benchmark(Baseline = true)]
        public string tTest1nameof()
        {
            return nameof(TestingEnum.Val1);
        }

        [Benchmark]
        public string tTest1Interpolated()
        {
            return $"{TestingEnum.Val1}";
        }

        [Benchmark]
        public string tTest1ToString()
        {
            return TestingEnum.Val1.ToString();
        }

    }
}