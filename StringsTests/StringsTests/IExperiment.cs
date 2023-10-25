using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests
{
	public interface IExperiment
	{
		const int Default = 0;
		void Run(int eCode = IExperiment.Default);
	}

	public interface IExperimentAsync
	{
		Task RunAsync(int eCode = IExperiment.Default);
	}
}
