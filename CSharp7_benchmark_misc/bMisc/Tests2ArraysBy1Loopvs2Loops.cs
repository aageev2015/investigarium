// cache hit optimization
// https://www.linkedin.com/pulse/cpu-cache-optimization-c-example-ashutosh-pareek/
// results: one loop faster
// struct vs int - same as expected
// struct vs class - struct faster as expected
// 1 loop vs 2 loop - 1 loop 20% faster. This not match with article. Something wrong with this test probably

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests2ArraysBy1Loopvs2Loops
    {
        [Params(10, 100, 10000, 100000)]
        public int ArrayLength { get; set; }

        private int[] IntArray1;
        private int[] IntArray2;

        private EntityStruct[] StructArray1;
        private EntityStruct[] StructArray2;

        private EntityClass[] ClassArray1;
        private EntityClass[] ClassArray2;

        [GlobalSetup]
        public void GlobalSetup()
        {
            IntArray1 = Enumerable.Range(1, ArrayLength).Select(i => i).ToArray();
            IntArray2 = Enumerable.Range(1, ArrayLength).Select(i => i).ToArray();

            StructArray1 = Enumerable.Range(1, ArrayLength).Select(i => new EntityStruct() { Value = i }).ToArray();
            StructArray2 = Enumerable.Range(1, ArrayLength).Select(i => new EntityStruct() { Value = i }).ToArray();

            ClassArray1 = Enumerable.Range(1, ArrayLength).Select(i => new EntityClass() { Value = i }).ToArray();
            ClassArray2 = Enumerable.Range(1, ArrayLength).Select(i => new EntityClass() { Value = i }).ToArray();
        }


        [Benchmark(Baseline = true)]
        public int tInt1Loop()
        {
            var sum = 0;
            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++IntArray1[i];
                sum += ++IntArray2[i];
            }

            return sum;
        }

        [Benchmark]
        public int tInt2Loop()
        {
            var sum = 0;
            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++IntArray1[i];
            }

            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++IntArray2[i];
            }
            return sum;
        }

        [Benchmark]
        public int tStruct1Loop()
        {
            var sum = 0;
            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++StructArray1[i].Value;
                sum += ++StructArray2[i].Value;
            }

            return sum;
        }

        [Benchmark]
        public int tStruct2Loop()
        {
            var sum = 0;
            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++StructArray1[i].Value;
            }

            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++StructArray2[i].Value;
            }

            return sum;
        }

        [Benchmark]
        public int tClass1Loop()
        {
            var sum = 0;
            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++ClassArray1[i].Value;
                sum += ++ClassArray2[i].Value;
            }

            return sum;
        }

        [Benchmark]
        public int tClass2Loop()
        {
            var sum = 0;
            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++ClassArray1[i].Value;
            }

            for (int i = 0; i < ArrayLength; i++)
            {
                sum += ++ClassArray2[i].Value;
            }

            return sum;
        }

    }

    public class EntityClass
    {
        public int Value { get; set; } = 0;
    }

    public struct EntityStruct
    {
        public int Value { get; set; }
    }


}