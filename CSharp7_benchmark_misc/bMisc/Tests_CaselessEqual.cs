// https://www.linkedin.com/posts/davidcallan_dotnet-csharp-activity-7162409967189155840-hlt1	

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    [Config(typeof(PercentConfig))]
    public class Tests_CaselessEqual
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private readonly string testString1 = "Hellow world!";
        private readonly string testString2 = "HELLOW WORLD!";
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public bool tEqualsWithOrdinal() => string.Equals(testString1, testString2, StringComparison.OrdinalIgnoreCase);

        [Benchmark]
        public int tCompareWithOrdinal() => string.Compare(testString1, testString2, StringComparison.OrdinalIgnoreCase);

        [Benchmark]
        public bool tTestToUpper() => testString1.ToUpper() == testString2.ToUpper();

        [Benchmark]
        public bool tTestToLower() => testString1.ToLower() == testString2.ToLower();

    }
}