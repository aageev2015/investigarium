namespace NickChapsas
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class Tests1
	{
		List<int> data;

		[GlobalSetup]
		public void GlobalSetup()
		{
			data = Enumerable.Range(0, 100).ToList();
		}


		[Benchmark]
		public int TestWhereDirectSum()
		{
			return this.data.Where(filter).Count();
		}

		[Benchmark]
		public int TestWhereViaLambdaSum()
		{
			return this.data.Where(v => filter(v)).Count();
		}

		private bool filter(int val)
		{
			return val > 40;
		}

	}
}