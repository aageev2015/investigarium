// Not done at all
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class TestsObjectPoolVsNew
    {
        [Params(2, 4)]
        public int Value;


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public int tTest()
        {
            return 0;
        }

    }
}