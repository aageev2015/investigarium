using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net6benchmark.Benchmark
{
	public interface IBenchmarkRunner<TResult> where TResult: IBenchmarkResult
	{
        TResult Run(int iterations, IBenchmark benchmark);
		TResult Run(IBenchmark benchmark);
        void Reset();
	}
}
