using System.Runtime.CompilerServices;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class TestsSkipLocalsInit
    {
        [Params(0, 10, 64, 255, 1023)]
        public int Size;


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [SkipLocalsInit]
        [Benchmark(Baseline = true)]
        public int tNoInit_stack()
        {
            Span<int> arrSpan = stackalloc int[this.Size];
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i;
            }
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                sum += arrSpan[i];
            }
            return sum;
        }

        [Benchmark]
        public int tWithInit_stack()
        {
            Span<int> arrSpan = stackalloc int[this.Size];
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i;
            }
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                sum += arrSpan[i];
            }
            return sum;
        }

        [SkipLocalsInit]
        [Benchmark]
        public int tNoInit_stack_direct()
        {
            Span<int> arrSpan = stackalloc int[this.Size];
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i;
                sum += arrSpan[i];
            }
            return sum;
        }

        [Benchmark]
        public int tWithInit_stack_direct()
        {
            Span<int> arrSpan = stackalloc int[this.Size];
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i;
                sum += arrSpan[i];
            }
            return sum;
        }

        [SkipLocalsInit]
        [Benchmark]
        public int tNoInit()
        {
            Span<int> arrSpan = new int[this.Size];
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i;
            }
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                sum += arrSpan[i];
            }
            return sum;
        }

        [Benchmark]
        public int tWithInit()
        {
            Span<int> arr = new int[this.Size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        [SkipLocalsInit]
        [Benchmark]
        public int tNoInit_DirectUse()
        {
            Span<int> arr = new int[this.Size];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
                sum += arr[i];
            }
            return sum;
        }

        [Benchmark]
        public int tWithInit_DirectUse()
        {
            Span<int> arrSpan = new int[this.Size];
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i;
                sum += arrSpan[i];
            }
            return sum;
        }



    }
}