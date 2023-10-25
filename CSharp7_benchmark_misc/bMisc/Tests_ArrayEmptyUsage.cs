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

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class Tests_ArrayEmptyUsage
	{

		private IEnumerable<string> sourceEnumerable;

		[GlobalSetup]
		public void GlobalSetup()
		{
			sourceEnumerable = new List<string>();
		}


		[Benchmark]
		public int tDefaultWay()
		{
			int[] arr = new int[sourceEnumerable.Count()];
			var result = doWork(arr);
			return result;
		}

		[Benchmark]
		public int tWithArrayEmpty()
		{
			var count = sourceEnumerable.Count();
			int[] arr = count == 0 ? Array.Empty<int>() : new int[count];
			var result = doWork(arr);
			return result;
		}

		public int doWork(int[] arr)
		{
			var i = 0;
			foreach (var val in sourceEnumerable)
			{
				arr[i++] = val.Length;
			}
			return i;
		}

	}
}