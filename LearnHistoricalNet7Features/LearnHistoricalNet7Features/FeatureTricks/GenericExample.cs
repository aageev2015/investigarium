using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHistoricalNet7_8Features.FeatureTricks
{
	public record RecordExample
	{
		private static RecordExample rootParent = new RecordExample();

		public int Id { get; set; } = 0;
		public string Name { get; set; } = string.Empty;

		private RecordExample parent = rootParent;
		public ref readonly RecordExample Parent => ref parent;
		public RecordExample() { }
		public void ChangeParent(RecordExample newParent)
		{
			parent = newParent;
		}
	};

	public record DailyTemperature(double HighTemp, double LowTemp);
	public readonly record struct DailyTemperature1(double HighTemp, double LowTemp);

	public class GenericExample
	{
		void LocalFunction<T>(T param) {

		}
	}
}
