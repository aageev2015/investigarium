namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_ThreadContextSwitchDelayTry
    {
        private const long iterations = 100;

        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public Guid tSyncronus()
        {
            return Guid.NewGuid();
        }


    }



}