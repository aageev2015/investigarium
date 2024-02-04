// Test how using struct can optimize mass data updating. Based on falling data into CPU cache
// inspired by: https://www.c-sharpcorner.com/article/how-to-improve-applications-execution-performance/

using bStruct1.Data;

namespace bStruct1
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsIntArrayStackalloc
	{
		[Params(10, 100, 1000, 10000)]
		public int Length;

		public DateTime ConstDate = DateTime.Now;

		[GlobalSetup]
		public void GlobalSetup()
		{
		}

		[Benchmark]
		public int class_case()
		{
			var arr = new ClassTinyExample[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new ClassTinyExample(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int class_case_CachedLength()
		{
			var arr = new ClassTinyExample[Length];
			for (int i = 0; i < Length; i++)
			{
				arr[i] = new ClassTinyExample(-1);
			}

			for (int i = 0; i < Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int class_WithString_case()
		{
			var arr = new ClassWithStringExample[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new ClassWithStringExample("Const str", -1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int class_Huge20_case()
		{
			var arr = new ClassHuge20Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new ClassHuge20Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int class_Huge36_case()
		{
			var arr = new ClassHuge36Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new ClassHuge36Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int class_Huge52_case()
		{
			var arr = new ClassHuge52Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new ClassHuge52Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int class_Huge116_case()
		{
			var arr = new ClassHuge116Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new ClassHuge116Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_case()
		{
			var arr = new StructTinyExample[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new StructTinyExample(ConstDate, -1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_case_Stackalloc()
		{
			Span<StructTinyExample> arr = stackalloc StructTinyExample[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new StructTinyExample(ConstDate, -1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_case_CachedLength()
		{
			var arr = new StructTinyExample[Length];
			for (int i = 0; i < Length; i++)
			{
				arr[i] = new StructTinyExample(ConstDate, -1);
			}

			for (int i = 0; i < Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_WithString_case()
		{
			var arr = new StructWithStringExample[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				//TODO: need remove any string formatting, and rerun;
				arr[i] = new StructWithStringExample("Const Str", -1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_Huge20_case()
		{
			var arr = new StructHuge20Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new StructHuge20Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_Huge36_case()
		{
			var arr = new StructHuge36Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new StructHuge36Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_Huge52_case()
		{
			var arr = new StructHuge52Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new StructHuge52Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}

		[Benchmark]
		public int struct_Huge116_case()
		{
			var arr = new StructHuge116Example[Length];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = new StructHuge116Example(-1);
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value = i * i;
			}

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i].Value++;
			}

			return 0;
		}
	}
}