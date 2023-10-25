// Result analysis not finished or not clear: Each nested await has +15ms. Expected only 1 await.

using System.Runtime.CompilerServices;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsAwaitOverhead
	{
		[Params(100, 1000, 10000)]
		public int WorkIterations;


		[GlobalSetup]
		public void GlobalSetup()
		{
		}

		#region [Benchmark]
		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public async Task<int> tWithAwait1()
		{
			var result = await awaitMethod1(10);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public int tNoAwait1()
		{
			var result = method1(10);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public async Task<int> tWithAwait4()
		{
			var result = await awaitMethod4(10);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int tNoAwait4()
		{
			var result = method4(10);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public async Task<int> tWithAwait8()
		{
			var result = await awaitMethod8(10);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int tNoAwait8()
		{
			var result = method8(10);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public async Task<int> tRecursiveWithAwait4()
		{
			var result = await recursiveAwaitMethod(10, 4);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int tRecursiveNoAwait4()
		{
			var result = recursiveMethod(10, 4);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public async Task<int> tRecursiveWithAwait8()
		{
			var result = await recursiveAwaitMethod(10, 8);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int tRecursiveNoAwait8()
		{
			var result = recursiveMethod(10, 8);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public async Task<int> tRecursiveWithAwait32()
		{
			var result = await recursiveAwaitMethod(10, 32);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int tRecursiveNoAwait32()
		{
			var result = recursiveMethod(10, 32);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public async Task<int> tRecursiveWithAwait512()
		{
			var result = await recursiveAwaitMethod(10, 512);
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int tRecursiveNoAwait512()
		{
			var result = recursiveMethod(10, 512);
			return result;
		}
		#endregion [Benchmark]


		#region With await
		private async Task<int> awaitMethod8(int v)
		{
			return await awaitMethod7(70) + v;
		}

		private async Task<int> awaitMethod7(int v)
		{
			return await awaitMethod6(60) + v;
		}

		private async Task<int> awaitMethod6(int v)
		{
			return await awaitMethod5(50) + v;
		}

		private async Task<int> awaitMethod5(int v)
		{
			return await awaitMethod4(40) + v;
		}

		private async Task<int> awaitMethod4(int v)
		{
			return await awaitMethod3(30) + v;
		}

		private async Task<int> awaitMethod3(int v)
		{
			return await awaitMethod2(20) + v;
		}

		private async Task<int> awaitMethod2(int v)
		{
			return await awaitMethod1(10) + v;
		}

		private async Task<int> awaitMethod1(int v)
		{
			int result = await Task.Run<int>(() =>
			{
				int _v = v;
				return doWork() + v;
			});
			return result;
		}
		#endregion With await


		#region No await
		private int method8(int v)
		{
			return method7(70) + v;
		}

		private int method7(int v)
		{
			return method6(60) + v;
		}

		private int method6(int v)
		{
			return method5(50) + v;
		}

		private int method5(int v)
		{
			return method4(40) + v;
		}

		private int method4(int v)
		{
			return method3(30) + v;
		}

		private int method3(int v)
		{
			return method2(20) + v;
		}

		private int method2(int v)
		{
			return method1(10) + v;
		}

		private int method1(int v)
		{
			int result = doWork() + v;
			return result;
		}
		#endregion No await


		#region Recursive
		private async Task<int> recursiveAwaitMethod(int v, int iteration)
		{
			int result;
			if (iteration > 0)
			{
				result = await recursiveAwaitMethod(v, iteration - 1) + v;
			}
			else
			{
				result = doWork() + v;
			}
			return result;
		}

		private int recursiveMethod(int v, int iteration)
		{
			int result;
			if (iteration > 0)
			{
				result = recursiveMethod(v, iteration - 1) + v;
			}
			else
			{
				result = doWork() + v;
			}
			return result;
		}
		#endregion Recursive


		#region Common
		private int doWork()
		{
			int result = 0;
			for (int i = 0; i < this.WorkIterations; i++)
			{
				result += i;
			}
			return result;
		}
		#endregion Common
	}
}