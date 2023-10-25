using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StringsTests.Experiments;
using AsyncBreakfast = StringsTests.Experiments.AsyncBreakfast;

namespace StringsTests
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//(new StringsAllocation(1000)).Run();
			//new LambdaClosures().Run();
			//new FunWithDelegates().Run();
			//new IntToStringWithBase().Run();
			// new FunWithVirtuals().Run();
			new FunWithLinq().Run();
		}

		public async static Task Main1(string[] args)
		{
			await (new AsyncBreakfast.AsyncBreakfast()).RunAsync();
		}

	}
}
