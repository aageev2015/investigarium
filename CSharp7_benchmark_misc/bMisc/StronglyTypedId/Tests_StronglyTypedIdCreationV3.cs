namespace bMisc.StronglyTypedId
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_StronglyTypedIdCreationV3
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public Guid tPureNewId()
        {
            return Guid.NewGuid();
        }

        [Benchmark]
        public ManualReadonlyStructEntityId tManualReadonlyStruct()
        {
            return ManualReadonlyStructEntityId.New();
        }

        [Benchmark]
        public ManualStructEntityId tManualStruct()
        {
            return ManualStructEntityId.New();
        }

        [Benchmark]
        public ManualClassEntityId tManualClassStruct()
        {
            return ManualClassEntityId.New();
        }

        [Benchmark]
        public RecordStructEntityId tRecordStruct()
        {
            return RecordEntityId.NewStruct();
        }

        [Benchmark]
        public RecordClassEntityId tRecordClass()
        {
            return RecordEntityId.NewClass();
        }
    }
}