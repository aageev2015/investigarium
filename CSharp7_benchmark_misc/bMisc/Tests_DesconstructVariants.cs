// Not finished
using System.Runtime.CompilerServices;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [DisassemblyDiagnoser]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_DesconstructVariants
    {
        private record TheRecord(int Int1, int Int2, int Int3);
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        (int Int1, int Int2, int Int3) someData;
        TheRecord theRecord;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
            someData = (5, 55, 555);
            theRecord = new(5, 55, 555);
        }


        [Benchmark(Baseline = true)]
        public int tTupleStraightforward()
        {
            var i1 = someData.Int1;
            var i2 = someData.Int2;
            var i3 = someData.Int3;
            return calc(i1, i2, i3);
        }

        [Benchmark]
        public int tTupleDeconstruct()
        {
            var (i1, i2, i3) = someData;
            return calc(i1, i2, i3);
        }

        [Benchmark]
        public int tTupleDeconstructOne()
        {
            var (i1, _, _) = someData;
            return calc(i1, i1, i1);
        }

        [Benchmark]
        public int tTupleGetOne()
        {
            var i1 = someData.Int1;
            return calc(i1, i1, i1);
        }

        [Benchmark]
        public int tTupleDeconstructTwo()
        {
            var (i1, _, i3) = someData;
            return calc(i1, i1, i3);
        }

        [Benchmark]
        public int tRecordDeconstruct()
        {
            var (i1, i2, i3) = theRecord;
            return calc(i1, i2, i3);
        }

        [Benchmark]
        public int tRecordSraightforward()
        {
            var i1 = theRecord.Int1;
            var i2 = theRecord.Int2;
            var i3 = theRecord.Int3;
            return calc(i1, i2, i3);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private int calc(int i1, int i2, int i3)
        {
            return i1 + i2 + i3;
        }
    }
}