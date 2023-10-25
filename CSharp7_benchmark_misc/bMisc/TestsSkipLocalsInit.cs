using System.Runtime.CompilerServices;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsSkipLocalsInit
	{
		[Params(0, 10, 64, 255)]
		public int Size;


		[GlobalSetup]
		public void GlobalSetup()
		{
		}


		[Benchmark]
		public int tMethodNoInit()
		{
			return MethodNoInit();
		}

		[Benchmark]
		public int tMethodWithInit()
		{
			return MethodWithInit();
		}

		[SkipLocalsInit]
		public int MethodNoInit()
		{
			Span<int> arrSpan = stackalloc int[this.Size];
			for (int i = 0; i < arrSpan.Length; i++)
			{
				arrSpan[i] = i;
			}
			int sum = 0;
			for (int i = 0; i < arrSpan.Length; i++)
			{
				sum += arrSpan[i];
			}
			return sum;
		}

		public int MethodWithInit()
		{
			Span<int> arrSpan = stackalloc int[this.Size];
			for (int i = 0; i < arrSpan.Length; i++)
			{
				arrSpan[i] = i;
			}
			int sum = 0;
			for (int i = 0; i < arrSpan.Length; i++)
			{
				sum += arrSpan[i];
			}
			return sum;
		}

	}
}