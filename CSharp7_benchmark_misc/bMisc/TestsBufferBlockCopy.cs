namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsBufferBlockCopy
	{

		private readonly int size = 10 * 1024 * 1024;
		private readonly int copyOffset = 1 * 1024 * 1024 - 1;

		[Params(8, 32, 128, 512, 1024, 65536)]
		public int copyCount = 1024;

		private int[] testArray;

		[GlobalSetup]
		public void GlobalSetup()
		{
			testArray = Enumerable.Range(1, size).ToArray();
		}


		[Benchmark]
		public int tLoopAssign()
		{
			int[] copy = new int[copyCount];
			int lastIndex = copyOffset + copyCount;
			for (var i = 0; i < copyCount; i++)
			{
				copy[i] = testArray[copyOffset + i];
			}
			return doWork(copy);
		}

		[Benchmark]
		public int tArrayCopyNoOffset()
		{
			int[] copy = new int[copyCount];
			Array.Copy(testArray, copy, copyCount);
			return doWork(copy);
		}

		[Benchmark]
		public int tBufferBlockCopy()
		{
			int[] copy = new int[copyCount];
			Buffer.BlockCopy(testArray, copyOffset, copy, 0, copyCount);
			return doWork(copy);
		}

		public int doWork(int[] array)
		{
			var len = array.Length;
			int result = 0;
			for (var i = 0; i < len; i++)
			{
				result += array[i];
			}
			return result;
		}

		public int doWork(Span<int> array)
		{
			int result = array[0] + array[array.Length - 1];
			return result;
		}

	}
}