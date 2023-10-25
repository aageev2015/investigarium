using System.Collections;
using System.Runtime.InteropServices;

namespace LearnHistoricalNet7_8Features.Stocks
{
	public class Stock12_mem_allocs_tests
	{
		static long startMem = 0, stopMem = 0;
		private static void StartMemoryUsage()
		{
			GC.Collect();
			GC.Collect();
			startMem = GC.GetTotalMemory(true);
		}
		private static long StopMemoryUsage()
		{
			GC.Collect();
			GC.Collect();
			stopMem = GC.GetTotalMemory(true);

			return stopMem - startMem;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		struct ProductIdValue
		{
			bool B1 { get; set; }
			bool B2 { get; set; }
			//bool B3 { get; set; }
			/*int I1 { get; set; }
			int I2 { get; set; }
			int I3 { get; set; }
			int I4 { get; set; }*/
		};


		public static void Do()
		{
			int size = 100000;
			StartMemoryUsage();
			var val = new BitArray(size);
			var mem = StopMemoryUsage();
			Console.WriteLine($"{(float)mem / size}");
		}
	}
}

