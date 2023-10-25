using System.Globalization;
using System.Text;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsGetMaxByteCount
	{

		private Encoding encoding;

		[ParamsSource(nameof(ExamplesValues))]
		public string Example;
		public IEnumerable<string> ExamplesValues()
		{
			return new[] { "", "A", "Short Normal Text", Data.TestResource.UTF8ComplexText };
		}

		public StringInfo ExampleAsInfo;

		[GlobalSetup]
		public void GlobalSetup()
		{
			encoding = new UTF8Encoding();
			ExampleAsInfo = new StringInfo(Example);
		}


		[Benchmark(Baseline = true)]
		public int tLength()
		{
			return this.Example.Length;
		}

		[Benchmark]
		public int tGetByteCount()
		{
			return encoding.GetByteCount(this.Example);
		}

		[Benchmark]
		public int tGetMaxByteCount()
		{
			return encoding.GetMaxByteCount(this.Example.Length);
		}

		[Benchmark]
		public int tLengthFromCachedStringInfo()
		{
			return ExampleAsInfo.LengthInTextElements;
		}

		[Benchmark]
		public int tLengthFromNewStringInfo()
		{
			return (new StringInfo(Example)).LengthInTextElements;
		}

	}
}