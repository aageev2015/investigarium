using System.Runtime.CompilerServices;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsBoxingUnboxing
	{
		[Params(10, 10000)]
		public int Qty;

		private object obj;

		[GlobalSetup]
		public void GlobalSetup()
		{
		}


		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tBoxing()
		{
			int sum = 0;
			for (int i = 0; i < this.Qty; i++)
			{
				this.obj = i;
				sum += i;
			}
			return sum;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tBoxingUnboxing()
		{
			int sum = 0;
			for (int i = 0; i < this.Qty; i++)
			{
				this.obj = i;
				sum += (int)this.obj;
			}
			return sum;
		}

		[Benchmark]
		public int tNothing()
		{
			int sum = 0;
			for (int i = 0; i < this.Qty; i++)
			{
				sum += i;
			}
			return sum;
		}

	}
}