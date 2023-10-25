//source: https://www.matt-helps.com/post/how-to-optimise-csharp-for-memory-access/

using BenchmarkDotNet.Columns;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsColdVsHotData
	{
		public int ArraySize { get; set; } = 100000;

		private Lukewarm[] Lukewarm { get; set; }
		private HotData[] HotData { get; set; }
		private ColdData[] ColdData { get; set; }
		private LukewarmStruct[] LukewarmStruct { get; set; }
		private HotDataStruct[] HotDataStruct { get; set; }
		private ColdDataStruct[] ColdDataStruct { get; set; }

		[GlobalSetup]
		public void GlobalSetup()
		{
			AllocateArrays();
		}

		private void AllocateArrays()
		{
			Lukewarm = new Lukewarm[ArraySize];
			HotData = new HotData[ArraySize];
			ColdData = new ColdData[ArraySize];

			for (var i = 0; i < ArraySize; i++)
			{
				Lukewarm[i] = new Lukewarm();
				HotData[i] = new HotData();
				ColdData[i] = new ColdData();
			}

			LukewarmStruct = new LukewarmStruct[ArraySize];
			HotDataStruct = new HotDataStruct[ArraySize];
			ColdDataStruct = new ColdDataStruct[ArraySize];
		}


		[Benchmark(Baseline = true)]
		public int tUpdateLukewarmClassesArray()
		{
			int sum = 0;
			for (int i = 0; i < ArraySize; i++)
			{
				sum += ++Lukewarm[i].MyHotData;
			}
			return sum;
		}

		[Benchmark]
		public int tUpdateHotDataClassesArray()
		{
			int sum = 0;
			for (int i = 0; i < ArraySize; i++)
			{
				sum += ++HotData[i].MyHotData;
			}
			return sum;
		}

		[Benchmark]
		public int tUpdateLukewarmStructsArray()
		{
			int sum = 0;
			for (int i = 0; i < ArraySize; i++)
			{
				sum += ++LukewarmStruct[i].MyHotData;
			}
			return sum;
		}

		[Benchmark]
		public int tUpdateHotDataStructsArray()
		{
			int sum = 0;
			for (int i = 0; i < ArraySize; i++)
			{
				sum += ++HotDataStruct[i].MyHotData;
			}
			return sum;
		}

	}

	class Lukewarm
	{
		public int MyHotData { get; set; } = 0;
		public int MyColdData1 { get; set; } = 0;
		public int MyColdData2 { get; set; } = 0;
		public int MyColdData3 { get; set; } = 0;
	}

	class HotData
	{
		public int MyHotData { get; set; } = 0;
	}

	class ColdData
	{
		public int MyColdData1 { get; set; } = 0;
		public int MyColdData2 { get; set; } = 0;
		public int MyColdData3 { get; set; } = 0;
	}

	struct LukewarmStruct
	{
		public int MyHotData { get; set; }
		public int MyColdData1 { get; set; }
		public int MyColdData2 { get; set; }
		public int MyColdData3 { get; set; }
	}

	struct HotDataStruct
	{
		public int MyHotData { get; set; }
	}

	struct ColdDataStruct
	{
		public int MyColdData1 { get; set; }
		public int MyColdData2 { get; set; }
		public int MyColdData3 { get; set; }
	}

}