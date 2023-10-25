using System.Buffers;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsArrayPool
	{
		[Params(/*Int32[6]*/ new[] { 2, 3, 5, 7, 13, 23 },
				/*Int32[5]*/ new[] { 10, 100, 1000, 10000, 100000 },
				/*Int32[18]*/ new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 },
				/*Int32[4]*/ new[] { 1000, 1000, 1000, 1000 })]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public int[] Lengths;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		[GlobalSetup]
		public void GlobalSetup()
		{
		}

		#region Benchmarks
		[Benchmark]
		public int tNewArray()
		{
			int sum = 0;
			var lenCount = this.Lengths.Length;
			for (int i = 0; i < lenCount; i++)
			{
				var arr = new int[this.Lengths[i]];
				doInit(arr);
				sum += doWork(arr);
			}
			return sum;
		}

		[Benchmark]
		public int tArrayPoolRent_ForceReturn()
		{
			int sum = 0;
			var pool = ArrayPool<int>.Shared;
			var lenCount = this.Lengths.Length;
			for (int i = 0; i < lenCount; i++)
			{
				var arr = pool.Rent(this.Lengths[i]);
				doInit(arr);
				sum += doWork(arr);
				pool.Return(arr);
			}
			return sum;
		}

		[Benchmark]
		public int tArrayPoolRent_OnEndReturn()
		{
			int sum = 0;
			var lenCount = this.Lengths.Length;
			var arrays = new int[lenCount][];
			var pool = ArrayPool<int>.Shared;
			for (int i = 0; i < lenCount; i++)
			{
				var arr = pool.Rent(this.Lengths[i]);
				doInit(arr);
				sum += doWork(arr);
				arrays[i] = arr;
			}
			for (int i = 0; i < lenCount; i++)
			{
				pool.Return(arrays[i]);
			}
			return sum;
		}

		[Benchmark]
		public int tArrayPoolRent_WorkSeparated()
		{
			int sum = 0;
			var lenCount = this.Lengths.Length;
			var arrays = new int[lenCount][];
			var pool = ArrayPool<int>.Shared;
			for (int i = 0; i < lenCount; i++)
			{
				var arr = pool.Rent(this.Lengths[i]);
				doInit(arr);
				arrays[i] = arr;
			}
			for (int i = 0; i < lenCount; i++)
			{
				sum += doWork(arrays[i]);
			}
			for (int i = 0; i < lenCount; i++)
			{
				pool.Return(arrays[i]);
			}
			return sum;
		}

		[Benchmark]
		public int tStackallock()
		{
			int sum = 0;
			var lenCount = this.Lengths.Length;
			for (int i = 0; i < lenCount; i++)
			{
#pragma warning disable CA2014 // Do not use stackalloc in loops
				Span<int> arr = stackalloc int[this.Lengths[i]];
#pragma warning restore CA2014 // Do not use stackalloc in loops
				doInit(arr);
				sum += doWork(arr);
			}
			return sum;
		}
		#endregion



		#region Common
		private void doInit(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = i;
			}
		}

		private int doWork(int[] arr)
		{
			int sum = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				sum += arr[i];
			}
			return sum;
		}
		#endregion

		private void doInit(Span<int> arr)
		{
			var lenCount = arr.Length;
			for (int i = 0; i < lenCount; i++)
			{
				arr[i] = i;
			}
		}

		private int doWork(Span<int> arr)
		{
			int sum = 0;
			var lenCount = arr.Length;
			for (int i = 0; i < lenCount; i++)
			{
				sum += arr[i];
			}
			return sum;
		}

	}
}