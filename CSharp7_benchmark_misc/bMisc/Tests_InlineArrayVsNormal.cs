// Not finished
namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_InlineArrayVsNormal
    {
        public const int CArrayLength = 1000;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private int[] normalArray;
        private AnItem<int> inlineArray;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [System.Runtime.CompilerServices.InlineArray(CArrayLength)]
        public struct AnItem<T>
        {
            private T _item;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            normalArray = Enumerable.Range(0, CArrayLength).ToArray();
            inlineArray = new AnItem<int>();
            for (int i = 0; i < CArrayLength; i++)
            {
                inlineArray[i] = normalArray[i];
            }
        }


        [Benchmark(Baseline = true)]
        public int tTestInlineArray()
        {
            int result = 0;
            for (int i = 0; i < CArrayLength; i++)
            {
                inlineArray[i] = i * 5;
                result += inlineArray[i];
            }

            return result;
        }

        [Benchmark()]
        public int tTest1NormalArray()
        {
            int result = 0;
            for (int i = 0; i < CArrayLength; i++)
            {
                normalArray[i] = i * 5;
                result += normalArray[i];
            }

            return result;
        }

    }


}