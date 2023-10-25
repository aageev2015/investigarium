namespace bExceptions1
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
    [RankColumn]
	public class Tests
	{
		[GlobalSetup]
		public void GlobalSetup()
		{
		}

		[Benchmark]
		public int no_exception()
		{
			return 0;
		}

		[Benchmark]
		public int throw_()
		{
			return 0;
		}
	}
}