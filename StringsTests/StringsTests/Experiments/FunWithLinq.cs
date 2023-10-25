using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests.Experiments
{
	public class FunWithLinq : IExperiment
	{
		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		public void Run(int eCode = 0)
		{
			var sw = new Stopwatch();

			var theList = Enumerable.Range(1, 1000000).ToList();
			sw.Start();
			int result = 0;
			for (var i = 1; i < 1000000; i++) { 
				var n = theList.Take(100000);
			}
			sw.Stop(); sw.Reset();
			Console.WriteLine($"{sw.ElapsedMilliseconds}");

			sw.Start();
			for (var i = 1; i < 1000000; i++) { 
				result += theList.Take(100000).Skip(10000).First();
			}
			sw.Stop(); sw.Reset();
			Console.WriteLine(result);
			Console.WriteLine($"{sw.ElapsedMilliseconds}");
		}
	}
}
