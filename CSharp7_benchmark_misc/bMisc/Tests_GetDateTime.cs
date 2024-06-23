// Not finished
using System.Diagnostics;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_GetDateTime
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {

        }

        [Benchmark()]
        [Arguments(10)]
        [Arguments(100)]
        [Arguments(1000)]
        public int tBaseLine10Loop(int count)
        {
            var aggregate = 0;
            for (var i = 0; i < count; i++)
            {
                aggregate += i;
            }
            return aggregate;
        }

        [Benchmark(Baseline = true)]
        public DateTime tDateTimeNow()
        {
            return DateTime.Now;
        }

        [Benchmark]
        public DateTime tDateTimeUtcNow()
        {
            return DateTime.UtcNow;
        }

        [Benchmark]
        public DateTime tDateTimeNew()
        {
            return new DateTime();
        }

        [Benchmark]
        public Stopwatch tStopwatchStartNew()
        {
            return Stopwatch.StartNew();
        }

    }
}