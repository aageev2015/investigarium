// Results:
//	+ timeBeginPeriod-based delay better for less than 15ms
//	+ timeBeginPeriod-based not consume processor
//	- timeBeginPeriod can be called by any program!!!  timer interrupt is a global resource.
// Intresting:
//	- Long-read: https://randomascii.wordpress.com/2020/10/04/windows-timer-resolution-the-great-rule-change/
//		1,000 ms divided by 64 = 15.625. Basic Windows interruptions intervals
// Conclusion: (about possible use-cases where timeBeginPeriod can be used)
//	- your application is dedicated(only valuable application) for machine. 
//  - required unfrequent but precice wait. Once per 15ms probably
// Questions:
//	- how this works in Docker?
//	- can OS policies or else pervent from using this or make it just do nothing?

using System.Diagnostics;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_StopwatchVsDateTime
    {

        private Stopwatch swCached;
        private DateTime dtCached;


        [GlobalSetup]
        public void GlobalSetup()
        {
            swCached = new Stopwatch();
            swCached.Start();
            dtCached = DateTime.Now;
        }


        [Benchmark(Baseline = true)]
        public long tStopwatchGet()
        {
            return swCached.ElapsedMilliseconds;
        }

        [Benchmark]
        public long tDateTimeGet()
        {
            return (DateTime.Now - dtCached).Milliseconds;
        }

        public long tStopwatchWithInit()
        {
            Stopwatch sw = new();
            sw.Start();
            return sw.ElapsedMilliseconds;
        }

        public long tDateTimeWithInit()
        {
            var dt = DateTime.Now;
            return (DateTime.Now - dt).Milliseconds;
        }

    }
}