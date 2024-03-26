using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;

namespace Tests_GCAllocateArray.BenchamrkConfigs
{
    public class PercentConfig : ManualConfig
    {
        public PercentConfig()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}
