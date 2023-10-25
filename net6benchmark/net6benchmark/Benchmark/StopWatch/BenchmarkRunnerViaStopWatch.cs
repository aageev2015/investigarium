using pUnit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6benchmark.Benchmark.StopWatch
{
    public class BenchmarkRunnerViaStopWatch : IBenchmarkRunner<BenchmarkResultStopWatch>
    {
        private Stopwatch? _stopwatch;
        public TimeSpan? Time => _stopwatch?.Elapsed;
        public int MemoryUsage => throw new NotImplementedException();

        public BenchmarkRunnerViaStopWatch() { }

        public void Reset()
        {
            _stopwatch?.Reset();
            _stopwatch = null;
        }

        public BenchmarkResultStopWatch Run(int iterations, IBenchmark benchmark)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            for (var i = 0; i < iterations; i++)
            {
                benchmark.Run();
            }

            _stopwatch.Stop();

            return new BenchmarkResultStopWatch()
            {
                Title = benchmark.GetType().Name,
                Time = _stopwatch.Elapsed,
                Iterations = iterations
            };
        }

        public BenchmarkResultStopWatch Run(IBenchmark benchmark)
        {
            var profileMethodAttribute = benchmark.GetType()
                .GetMethod("Run")?
                .GetCustomAttributes(typeof(ProfileMethodAttribute), false)
                .FirstOrDefault() as ProfileMethodAttribute;
            var iterations = profileMethodAttribute?.Iterations ?? 1;

            return Run(iterations, benchmark);
        }
    }
}
