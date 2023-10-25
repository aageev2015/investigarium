using net6benchmark.Benchmark;
using pUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace net6benchmark.SingleAspect.Exceptions
{
	[ProfileClass]
	internal class BenchmarkThrowCatchException_Throw : IBenchmark
	{
		private BenchmarkThrowCatchExceptionBase logic = new BenchmarkThrowCatchExceptionBase();

		[ProfileMethod(200)]
		public void Run()
		{
			logic.catchingMethod(true);
		}
	}

	[ProfileClass]
	internal class BenchmarkThrowCatchException_NotThrow : IBenchmark
	{
		private BenchmarkThrowCatchExceptionBase logic = new BenchmarkThrowCatchExceptionBase();

		[ProfileMethod(10000)]
		public void Run()
		{
			logic.catchingMethod(false);
		}
	}

	[ProfileClass]
	internal class BenchmarkThrowCatchException_ValueCheckFail : IBenchmark
	{
		private BenchmarkThrowCatchExceptionBase logic = new BenchmarkThrowCatchExceptionBase();

		[ProfileMethod(10000)]
		public void Run()
		{
			logic.valueCheckingMethod(true);
		}
	}

	[ProfileClass]
	internal class BenchmarkThrowCatchException_ValueCheckSuccess : IBenchmark
	{
		private BenchmarkThrowCatchExceptionBase logic = new BenchmarkThrowCatchExceptionBase();

		[ProfileMethod(10000)]
		public void Run()
		{
			logic.valueCheckingMethod(false);
		}
	}

	internal class BenchmarkThrowCatchExceptionBase
	{
		struct RetValue
		{
			public int Value;
			public Exception Exception;
			public bool Success => Exception == null;
		}

		internal int catchingMethod(bool doThrow)
		{
			try
			{
				return throwingMethod(doThrow);
			}
			catch (Exception ex)
			{
			}
			return 0;
		}

		private int throwingMethod(bool doThrow)
		{
			if (doThrow) throw new Exception();

			return 1;
		}

		internal int valueCheckingMethod(bool doThrow)
		{
			var ret = valueFailingMethod(doThrow);

			return ret.Success ? ret.Value : 0;
		}

		private RetValue valueFailingMethod(bool doThrow)
		{
			if (doThrow) return new RetValue {
				Exception = new Exception()
			};

			return new RetValue {
				Value = 1
			};
		}
	}

}
