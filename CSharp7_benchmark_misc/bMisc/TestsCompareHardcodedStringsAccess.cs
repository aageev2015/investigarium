// compare int\string key for dictionary
// compare ways to hardcode keys in code
using System.Runtime.CompilerServices;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsCompareHardcodedStringsAccess
	{
		public int DictionaryLength { get; } = 200;
		private const string EnumStringValXX_Prefix = "SOME_LONG_STRING_CODE_XX_";

		public const string EnumStringVal1_Const = "SOME_LONG_STRING_CODE_1";
		public static readonly string EnumStringVal2_ReadonlyField = "SOME_LONG_STRING_CODE_2";
		public static string EnumStringVal3_Getter { get; } = "SOME_LONG_STRING_CODE_3";
		public static string EnumStringVal4_Lambda => "SOME_LONG_STRING_CODE_4"; // same as EnumStringVal3_Getter

		public const int EnumIntVal6_Const = 1022;
		public static readonly int EnumIntVal7_ReadonlyField = 1023;
		public static int EnumIntVal8_Getter { get; } = 1024;

		/*public enum TrueEnumKeys
		{
			EnumValX1, EnumValX2, EnumValX3, EnumValX4, EnumValX5, EnumValX6, EnumValX7, EnumValX8, EnumValX9,
			EnumVal8: 1025,
			EnumValX11, EnumValX12, EnumValX13, EnumValX14, EnumValX15, EnumValX16, EnumValX17, EnumValX18, EnumValX19
		}*/

		private Dictionary<string, int> EnumStringVal0_Hardcoded_Dict { get; set; }
		private Dictionary<string, int> EnumStringVal1_Const_Dict { get; set; }
		private Dictionary<string, int> EnumStringVal2_ReadonlyField_Dict { get; set; }
		private Dictionary<string, int> EnumStringVal3_Getter_Dict { get; set; }
		private Dictionary<string, int> EnumStringVal4_Lambda_Dict { get; set; }
		private Dictionary<int, int> EnumIntVal5_Hardcoded_Dict { get; set; }
		private Dictionary<int, int> EnumIntVal6_Const_Dict { get; set; }
		private Dictionary<int, int> EnumIntVal7_ReadonlyField_Dict { get; set; }
		private Dictionary<int, int> EnumIntVal8_Getter_Dict { get; set; }
		//private Dictionary<Enum, int> EnumStringVal3_GetterDict { get; set; }


		[GlobalSetup]
		public void GlobalSetup()
		{
			EnumStringVal0_Hardcoded_Dict = newBigStringDictWithKey("SOME_LONG_STRING_CODE_0");
			EnumStringVal1_Const_Dict = newBigStringDictWithKey(EnumStringVal1_Const);
			EnumStringVal2_ReadonlyField_Dict = newBigStringDictWithKey(EnumStringVal2_ReadonlyField);
			EnumStringVal3_Getter_Dict = newBigStringDictWithKey(EnumStringVal3_Getter);
			EnumStringVal4_Lambda_Dict = newBigStringDictWithKey(EnumStringVal4_Lambda);

			EnumIntVal5_Hardcoded_Dict = newBigIntDictWithKey(1021);
			EnumIntVal6_Const_Dict = newBigIntDictWithKey(EnumIntVal6_Const);
			EnumIntVal7_ReadonlyField_Dict = newBigIntDictWithKey(EnumIntVal7_ReadonlyField);
			EnumIntVal8_Getter_Dict = newBigIntDictWithKey(EnumIntVal8_Getter);
		}


		[Benchmark(Baseline = true)]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tStringHardcoded()
		{
			return EnumStringVal0_Hardcoded_Dict["SOME_LONG_STRING_CODE_0"];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tStringConst()
		{
			return EnumStringVal1_Const_Dict[EnumStringVal1_Const];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tStringReadonlyField()
		{
			return EnumStringVal2_ReadonlyField_Dict[EnumStringVal2_ReadonlyField];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tStringGetter()
		{
			return EnumStringVal3_Getter_Dict[EnumStringVal3_Getter];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tStringLambda()
		{
			return EnumStringVal4_Lambda_Dict[EnumStringVal4_Lambda];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tIntHardcoded()
		{
			return EnumIntVal5_Hardcoded_Dict[1021];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tIntConst()
		{
			return EnumIntVal6_Const_Dict[EnumIntVal6_Const];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tIntReadonlyField()
		{
			return EnumIntVal7_ReadonlyField_Dict[EnumIntVal7_ReadonlyField];
		}

		[Benchmark]
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public int tIntGetter()
		{
			return EnumIntVal8_Getter_Dict[EnumIntVal8_Getter];
		}

		#region Helpers
		private Dictionary<string, int> newBigStringDictWithKey(string middleKey)
		{
			var result = new Dictionary<string, int>(DictionaryLength);
			int i = 0;
			Action<int> loop = (lastI) =>
			{
				while (i < lastI)
				{
					result[EnumStringValXX_Prefix + i.ToString()] = 1;
					i++;
				}
			};

			loop(DictionaryLength / 2);
			result[middleKey] = 1;
			i++;
			loop(DictionaryLength);

			return result;
		}

		private Dictionary<int, int> newBigIntDictWithKey(int middleKey)
		{
			var result = new Dictionary<int, int>(DictionaryLength);
			int i = 0;
			int key = 0;
			Action<int> loop = (lastI) =>
			{
				while (i < lastI)
				{
					result[key] = 1;
					i++;
					key++;
				}
			};

			key = middleKey - DictionaryLength;
			loop(DictionaryLength / 2);
			result[middleKey] = 1;
			i++;
			key = middleKey + DictionaryLength;
			loop(DictionaryLength);

			return result;
		}
		#endregion
	}
}