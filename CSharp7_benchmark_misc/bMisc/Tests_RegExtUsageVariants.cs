// Not finished
using System.Text.RegularExpressions;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_RegExtUsageVariants
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Params("", "a", "Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable")]
        public string TestingString { get; set; }
        public const string TestingRegEx = @"cons.?\s";
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public int tTest1NewNocached()
        {
            var regex = new Regex("");
            return 0;
        }

    }
}