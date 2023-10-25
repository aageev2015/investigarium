using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests.Experiments
{
	public class StringsAllocation : IExperiment
	{
		private string[] array;
		public StringsAllocation(int count)
		{
			array = new string[count];
		}

		public void Run(int eCode = 0)
		{
			long currentAppAllocated = GC.GetTotalMemory(true) / 1024;
			long currentAppAllocated1 = GC.GetTotalMemory(false) / 1024;
		}
	}
}
