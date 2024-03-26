using System.Runtime.CompilerServices;

namespace bMisc.StronglyTypedId
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_StronglyTypedIdCreationV2
    {
        private const int count = 10000;
        private List<Guid> ids;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ids = Enumerable.Range(0, count).Select(i => Guid.NewGuid()).ToList();
        }


        [Benchmark(Baseline = true), MethodImpl(MethodImplOptions.NoInlining)]
        public List<Guid> tPureNewId()
        {
            return ids.Select(i => i).ToList();
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public List<ManualReadonlyStructEntityId> tManualReadonlyStruct()
        {
            return ids.Select(i => new ManualReadonlyStructEntityId(i)).ToList();
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public List<ManualStructEntityId> tManualStruct()
        {
            return ids.Select(i => new ManualStructEntityId(i)).ToList();
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public List<ManualClassEntityId> tManualClassStruct()
        {
            return ids.Select(i => new ManualClassEntityId(i)).ToList();
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public List<RecordStructEntityId> tRecordStruct()
        {
            return ids.Select(i => new RecordStructEntityId(i)).ToList();
        }

        [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
        public List<RecordClassEntityId> tRecordClass()
        {
            return ids.Select(i => new RecordClassEntityId(i)).ToList();
        }
    }
}