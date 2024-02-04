namespace bThreads
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class TestsThreadStaticVsNamedDataSlot
    {
        /*
		[Params(1, 2, 4, 8, 16)]
		public int ThreadCount;

		const int valuesCount = 160_000;

		private int countPerThread;
		private int[] data;
		private int sum;
		*/

        [GlobalSetup]
        public void GlobalSetup()
        {
            /*
			data = new int[valuesCount];
			var random = new Random();

			for (int i = 0; i < data.Length; i++)
			{
				data[i] = random.Next(1, 100);
			}

			countPerThread = data.Length / ThreadCount;
			Console.WriteLine(countPerThread);
			*/
        }

        /*
		[Benchmark]
		public int LockSynchronization()
		{
			sum = 0;
			object lockObject = new object();

			Parallel.For(0, ThreadCount, i =>
			{
				var firstInclusive = i * countPerThread;
				var lastExclusive = firstInclusive + countPerThread;
				for (int j = firstInclusive; j < lastExclusive; j++)
				{
					lock (lockObject)
					{
						sum += data[j];
					}
				}
			});

			return sum;
		}

		[Benchmark]
		public int InterlockedSynchronization()
		{
			sum = 0;

			Parallel.For(0, 10, i =>
			{
				var firstInclusive = i * countPerThread;
				var lastExclusive = firstInclusive + countPerThread;
				for (int j = firstInclusive; j < lastExclusive; j++)
				{
					Interlocked.Add(ref sum, data[j]);
				}
			});

			return sum;
		}

		[Benchmark]
		public int MutexSynchronization()
		{
			sum = 0;
			using var mutex = new Mutex();

			Parallel.For(0, 10, i =>
			{
				var firstInclusive = i * countPerThread;
				var lastExclusive = firstInclusive + countPerThread;
				for (int j = firstInclusive; j < lastExclusive; j++)
				{
					mutex.WaitOne();
					sum += data[j];
					mutex.ReleaseMutex();
				}
			});

			return sum;
		}

		[Benchmark]
		public int SemaphoreSynchronization()
		{
			sum = 0;
			using var semaphore = new Semaphore(1, 1);

			Parallel.For(0, 10, i =>
			{
				var firstInclusive = i * countPerThread;
				var lastExclusive = firstInclusive + countPerThread;
				for (int j = firstInclusive; j < lastExclusive; j++)
				{
					semaphore.WaitOne();
					sum += data[j];
					semaphore.Release();
				}
			});

			return sum;
		}
		*/

    }
}