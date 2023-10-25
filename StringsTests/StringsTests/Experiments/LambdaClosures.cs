using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests.Experiments
{
	public class LambdaClosures : IExperiment
	{
		public void Run(int eCode = 0)
		{
			Dictionary<int, string> someObject = null;
			Action lambda = () => {
				Console.WriteLine(someObject?.Count.ToString() ?? "null");
			};
			lambda();
			someObject = new Dictionary<int, string>()
			{
				[1] = "test1"
			};
			lambda();
			Console.ReadLine();
		}
	}
}
