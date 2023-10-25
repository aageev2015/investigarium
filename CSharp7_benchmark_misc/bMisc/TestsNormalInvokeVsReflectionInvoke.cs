// Result analysis not finished or not clear: Each nested await has +15ms. Expected only 1 await.

using System.Reflection;
using System.Runtime.CompilerServices;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsNormalInvokeVsReflectionInvoke
	{

		private MethodInfo methodInfo { get; set; }
		private object?[] methodParameters { get; set; }

		[GlobalSetup]
		public void GlobalSetup()
		{
			var type = typeof(TestsNormalInvokeVsReflectionInvoke);
			methodInfo = type.GetMethod("TestMethod");
			Console.WriteLine($"test TestMethod.Invoke: {(int?)methodInfo.Invoke(this, new object?[] { 200 })}");
			methodParameters = new object?[1];
		}

		[Benchmark(Baseline = true)]
		public int tStandartInvoke()
		{
			return TestMethod(200);
		}

		[Benchmark]
		public int? tReflectionNoCachedInvoke()
		{
			var type = typeof(TestsNormalInvokeVsReflectionInvoke);
			var method = type.GetMethod("TestMethod");
			return (int?)method.Invoke(this, new object?[] { 200 });
		}

		[Benchmark]
		public int? tReflectionCachedMethodInvoke()
		{
			return (int?)methodInfo.Invoke(this, new object?[] { 200 });
		}

		[Benchmark]
		public int? tReflectionEverythingPossibleInvoke()
		{
			methodParameters[0] = 200;
			return (int?)methodInfo.Invoke(this, methodParameters);
		}


		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public int TestMethod(int param)
		{
			return 5 * param;
		}

	}
}