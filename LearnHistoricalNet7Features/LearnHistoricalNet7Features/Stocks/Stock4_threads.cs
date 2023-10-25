namespace LearnHistoricalNet7_8Features
{
	public class Stock4_threads
	{

		public static void Do()
		{
			var pool = new Thread[10];
			for (int i = 0; i < 10; i++)
			{
				var thread = new Thread(() => Console.Write(i));
				thread.Start();
				pool[i] = thread;
			}
			for (var i = 0; i < pool.Length; i++)
			{
				pool[i].Join();
			}

			Console.WriteLine();
			for (int i = 0; i < 10; i++)
			{
				int tmp = i;
				var thread = new Thread(() => Console.Write(tmp));
				thread.Start();
			}
		}

	}
}

