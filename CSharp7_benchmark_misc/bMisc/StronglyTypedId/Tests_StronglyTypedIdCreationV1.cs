using System.Runtime.CompilerServices;

namespace bMisc.StronglyTypedId
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_StronglyTypedIdCreationV1
    {
        private const int iterations = 10000;

        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true), MethodImpl(MethodImplOptions.NoInlining)]
        public void tPureNewId()
        {
            for (var i = 0; i < iterations; i++)
            {
                Guid.NewGuid();
            }
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public void tManualReadonlyStruct()
        {
            for (var i = 0; i < iterations; i++)
            {
                ManualReadonlyStructEntityId.New();
            }
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public void tManualStruct()
        {
            for (var i = 0; i < iterations; i++)
            {
                ManualStructEntityId.New();
            }
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public void tManualClassStruct()
        {
            for (var i = 0; i < iterations; i++)
            {
                ManualClassEntityId.New();
            }
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public void tRecordStruct()
        {
            for (var i = 0; i < iterations; i++)
            {
                RecordEntityId.NewStruct();
            }
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public void tRecordClass()
        {
            for (var i = 0; i < iterations; i++)
            {
                RecordEntityId.NewClass();
            }
        }
    }
}