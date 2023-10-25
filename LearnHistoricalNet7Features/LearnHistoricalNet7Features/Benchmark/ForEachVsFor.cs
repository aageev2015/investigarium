// deprecated after benchmark tool discovered
using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace LearnHistoricalNet7_8Features.Benchmark
{
	public class ForEachVsFor
	{
		private readonly List<string> data = new List<string>();

		[GlobalSetup]
		public void GlobalSetup()
		{
			for (int i = 0; i < 100; i++)
			{
				string c = $"The Item {i}";
				data.Add(c);
			}
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int NoOpt_List_For_NoCache()
		{
			var result = 0;
			for (var i = 0; i < data.Count; i++)
			{
				result += data[i].Length;
			}
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int NoOpt_List_For()
		{
			var result = 0;
			var len = data.Count;
			for (var i = 0; i < len; i++)
			{
				result += data[i].Length;
			}
			return result;
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int NoOpt_For_Each()
		{
			var result = 0;
			foreach (var item in data)
			{
				result += item.Length;
			}
			return result;
		}

		[Benchmark]
		public int Opt_List_For_NoCache()
		{
			var result = 0;
			for (var i = 0; i < data.Count; i++)
			{
				result += data[i].Length;
			}
			return result;
		}

		[Benchmark]
		public int Opt_List_For()
		{
			var result = 0;
			var len = data.Count;
			for (var i = 0; i < len; i++)
			{
				result += data[i].Length;
			}
			return result;
		}

		[Benchmark]
		public int Opt_For_Each()
		{
			var result = 0;
			foreach (var item in data)
			{
				result += item.Length;
			}
			return result;
		}
	}
}
