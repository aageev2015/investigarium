namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsModulusPow2
	{
		[Params(0b1, 0b11, 0b1111, 0b11111111)] // 2, 4, 16, 256
		public int Divisor;

		private int[] testValues;


		[GlobalSetup]
		public void GlobalSetup()
		{
			testValues = new int[] {
				696208,976854,461773,572860,828285,
				498066,937467,390245,721043,92505,
				915460,641784,813057,353856,595084,
				918347,189904,192208,93214,288546,
				504852,956450,707167,270820,766868,
				765460,991046,713940,416774,402925,
				734294,893402,565122,467533,709630,
				972173,326302,845145,70111,683556,
				889554,875535,919354,962720,315311,
				125639,985037,104103,61592,112605,
				189727,982442,366393,81843,80640,
				905005,531368,64509,915907,466403,
				950995,50312,917293,675941,576474,
				792298,432978,856444,450306,47131,
				789559,235411,624889,547939,202710,
				773788,846427,628610,634149,903127,
				101405,538783,656655,208185,678194,
				126144,11421,152424,553893,741239,
				577471,44063,927449,166440,136538,
				855443,274360,441596,84202,402496
			};
		}


		[Benchmark]
		public int tPow2StandartModulus()
		{
			var sum = 0;
			foreach (var val in testValues)
			{
				sum += val % Divisor; //TODO: Divisor + 1;
			}
			return sum;
		}

		[Benchmark]
		public int tPow2BitwizeModulus()
		{
			var sum = 0;
			foreach (var val in testValues)
			{
				sum += val & Divisor;
			}
			return sum;
		}

	}
}