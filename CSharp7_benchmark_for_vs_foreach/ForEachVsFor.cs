using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CSharp7_benchmark_for_vs_foreach.Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
	public class ForEachVsFor
	{
        [ParamsSource(nameof(ItemCountRange))]
        public int ItemCount { get; set; }
        public IEnumerable<int> ItemCountRange => new[] { 10, 100, 10000 };

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private List<string> list;
		private string[] array;
        private int lengthCache;
        private IEnumerator<string> arrayEnumeratorCache;
        private IEnumerator<string> listEnumeratorCache;
        private volatile string[] volArray;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		[GlobalSetup]
        public void GlobalSetup()
        {
            list = new List<string>();
            array = new string[ItemCount];
            volArray = new string[ItemCount + 1];
            for(int i = 0; i < ItemCount; i++)
            {
                string data = $"The Item {i}";
                list.Add(data);
                array[i] = data;
                volArray[i] = data;
            }
            volArray[ItemCount] = "";
            this.lengthCache = ItemCount;
            this.listEnumeratorCache = list.GetEnumerator();
            this.arrayEnumeratorCache = (this.array as IEnumerable<string>).GetEnumerator();
        }
        /*
         * Skipped "has no sence" variations:
         * - caching Enumerable object for List with while loop
         * - caching Length\Count\Array.Cast<string> in GlobalSetup. This has slight positive effect when ItemCount < 10
         */

		#region List, Optimization off
		[Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int list_NoOpt_For()
        {
            var result = 0;
            for (var i = 0; i < list.Count; i++)
            {
                result += list[i].Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int list_NoOpt_For_LenCache()
        {
            var result = 0;
            var len = list.Count;
            for (var i = 0; i < len; i++)
            {
                result += list[i].Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int list_NoOpt_For_LenCacheGlobal()
        {
            var result = 0;
            var len = this.lengthCache;
            for (var i = 0; i < len; i++)
            {
                result += list[i].Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int list_NoOpt_Foreach()
        {
            var result = 0;
            foreach (var item in list)
            {
                result += item.Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int list_NoOpt_Foreach_EnumeratorCache()
        {
            var result = 0;
            var enumerator = this.listEnumeratorCache;
            enumerator.Reset();
            while(enumerator.MoveNext())
            {
                result += enumerator.Current.Length;
            }
            return result;
        }
		#endregion

        #region List
		[Benchmark]
        public int list_For()
        {
            var result = 0;
            for (var i = 0; i < list.Count; i++)
            {
                result += list[i].Length;
            }
            return result;
        }

        [Benchmark]
        public int list_For_LenCache()
        {
            var result = 0;
            var len = list.Count;
            for (var i = 0; i < len; i++)
            {
                result += list[i].Length;
            }
            return result;
        }

        [Benchmark]
        public int list_For_LenCacheGlobal()
        {
            var result = 0;
            var len = this.lengthCache;
            for (var i = 0; i < len; i++)
            {
                result += list[i].Length;
            }
            return result;
        }

        [Benchmark]
        public int list_Foreach()
        {
            var result = 0;
            foreach (var item in list)
            {
                result += item.Length;
            }
            return result;
        }

        [Benchmark]
        public int list_Foreach_EnumeratorCache()
        {
            var result = 0;
            var enumerator = this.listEnumeratorCache;
            enumerator.Reset();
            while(enumerator.MoveNext())
            {
                result += enumerator.Current.Length;
            }
            return result;
        }
		#endregion

		#region Array, Optimization off
        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int array_NoOpt_For()
        {
            var result = 0;
            for (var i = 0; i < array.Length; i++)
            {
                result += array[i].Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int array_NoOpt_For_LenCache()
        {
            var result = 0;
            var len = array.Length;
            for (var i = 0; i < len; i++)
            {
                result += array[i].Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int array_NoOpt_For_LenCacheGlobal()
        {
            var result = 0;
            var len = this.lengthCache;
            for (var i = 0; i < len; i++)
            {
                result += array[i].Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int array_NoOpt_Foreach()
        {
            var result = 0;
            foreach (var item in array)
            {
                result += item.Length;
            }
            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public int array_NoOpt_Foreach_EnumeratorCache()
        {
            var result = 0;
            var enumerator = this.arrayEnumeratorCache;
            enumerator.Reset();
            while(enumerator.MoveNext())
            {
                result += enumerator.Current.Length;
            }
            return result;
        }
		#endregion

        #region Array
		[Benchmark]
        public int array_For()
        {
            var result = 0;
            for (var i = 0; i < array.Length; i++)
            {
                result += array[i].Length;
            }
            return result;
        }

        [Benchmark]
        public int array_For_LenCache()
        {
            var result = 0;
            var len = array.Length;
            for (var i = 0; i < len; i++)
            {
                result += array[i].Length;
            }
            return result;
        }

        [Benchmark]
        public int array_For_LenCacheGlobal()
        {
            var result = 0;
            var len = this.lengthCache;
            for (var i = 0; i < len; i++)
            {
                result += array[i].Length;
            }
            return result;
        }

        [Benchmark]
        public int array_Foreach()
        {
            var result = 0;
            foreach (var item in array)
            {
                result += item.Length;
            }
            return result;
        }

        [Benchmark]
        public int array_Foreach_EnumeratorCache()
        {
            var result = 0;
            var enumerator = this.arrayEnumeratorCache;
            enumerator.Reset();
            while(enumerator.MoveNext())
            {
                result += enumerator.Current.Length;
            }
            return result;
        }
		#endregion

		#region Usafe Array
        //
        // Just for fun and comparation
        // Not practical, Not secure, Empty string termination required
        // 

        [Benchmark]
        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public unsafe int array_NoOpt_UnsafePtrArithmetics()
        {
            var result = 0;
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			fixed (string* fptr = this.volArray)
            {
                string* ptr = fptr;
                int len;
                do
                {
                    len = (*ptr).Length;
                    result += len;
                    ptr++;
                } while (len > 0);
            }
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
            return result;
        }

        [Benchmark]
        public unsafe int array_UnsafePtrArithmetics()
        {
            var result = 0;
#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			fixed (string* fptr = this.volArray)
            {
                string* ptr = fptr;
                int len;
                do
                {
                    len = (*ptr).Length;
                    result += len;
                    ptr++;
                } while (len > 0);
            }
#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
            return result;
        }
		#endregion

	}
}
