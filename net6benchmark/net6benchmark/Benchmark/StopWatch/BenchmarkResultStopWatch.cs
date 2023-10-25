using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6benchmark.Benchmark.StopWatch
{
    public readonly struct BenchmarkResultStopWatch : IBenchmarkResult
    {
		public BenchmarkResultStopWatch() {		}

        public string Title { get; init; } = "Unknown";
		public TimeSpan? Time { get; init; } = null;
        public int? MemoryUsage { get; init; } = null;
        public int Iterations { get; init; } = 0;
    }
}
