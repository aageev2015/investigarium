using Microsoft.Diagnostics.Tracing.Parsers.Clr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHistoricalNet7_8Features.FeatureTricks
{


	public static class RecordExperiments
	{
		public static void Run(TextWriter log)
		{
			var obj1 = new SomeRecord() {A = 1, B = 2, StructVal = new Point(5,6), ObjectVal = new SomeRecord() { A = 66 } };
			var obj2 = obj1 with { B = 44};
			obj2.A = 33;
			log.WriteLine(obj2);
		}
	}

	public record SomeRecord
	{
		public int A { get; set; }
		public int B { get; set; }
		public Point StructVal { get; set; }
		public SomeRecord? ObjectVal { get;set; } 
	}

	public class SomeClass
	{
		public int A { get; set; }
		public int B { get; set; }
		public Point SturcVal { get; set; }
		public SomeClass? ObjectVal { get;set; } 
	}
}
