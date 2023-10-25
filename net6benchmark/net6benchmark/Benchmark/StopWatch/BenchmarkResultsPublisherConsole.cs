using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace net6benchmark.Benchmark.StopWatch
{
    internal class BenchmarkResultsPublisherConsole : IBenchmarkResultPublisher<BenchmarkResultStopWatch>
    {
        public string TotalTimeFormat { get; init; } =      "total time elapsed: {0:c}";
        public string IterationTimeFormat { get; init; } =  "       1 iteration: {0:c}";
        public string IterationCountFormat { get; init; } = "        iterations: {0}";
        public string MemoryUsageFormat { get; init; } =    "      memory usage: {0}";

        public void Publish(BenchmarkResultStopWatch result)
        {
            Console.WriteLine(result.Title);
            Console.WriteLine("  " + TotalTimeFormat, result.Time);
            Console.WriteLine("  " + IterationTimeFormat, result.Time / result.Iterations);
            Console.WriteLine("  " + IterationCountFormat, result.Iterations);
            if (result.MemoryUsage.HasValue) Console.WriteLine("  " + MemoryUsageFormat, result.MemoryUsage.Value);
        }
    }
}
