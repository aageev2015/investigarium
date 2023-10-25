using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsFastAccessValue
	{

		int[] arr;

		[Params(0, 100, 999)]
		public int Index;

		[GlobalSetup]
		public void GlobalSetup()
		{
			arr = Enumerable.Range(1, 1000).ToArray();
		}


		[Benchmark]
		public int tNormalAccessValue()
		{
			return this.arr[this.Index];
		}

		[Benchmark]
		public int tFastAccessValue()
		{
			return FastAccessValue(this.arr, this.Index);
		}

		[Benchmark]
		public int tFastAccessValueUnsafe()
		{
			return FastAccessValueUnsafe(this.arr, this.Index);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T FastAccessValue<T>(T[] ar, int index)
		{
			ref T tableRef = ref MemoryMarshal.GetArrayDataReference(ar);
			return Unsafe.Add(ref tableRef, (nint)index);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe T FastAccessValueUnsafe<T>(T[] ar, int index) where T : unmanaged
		{
			fixed (T* ptr = ar)
			{
				return ptr[index];
			}
		}
	}
}