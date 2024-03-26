using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;

namespace bMisc.BenchamrkConfigs
{
    public class PercentConfig : ManualConfig
    {
        public PercentConfig()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}
