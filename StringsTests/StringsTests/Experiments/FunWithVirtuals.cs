using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests.Experiments
{

	public class FunWithVirtuals : IExperiment
	{

		public void Run(int eCode = 0)
		{
			SomeBase obj = new SomeChild1();
			obj.DoVirtual();
			obj.DoNovirtual();
			((SomeChild1)obj).DoNovirtual();
		}

	}

	class SomeBase
	{
		public virtual void DoVirtual() {
			Console.WriteLine($"{nameof(SomeBase)}.{nameof(DoVirtual)}. this.GetType={this.GetType().Name}");
		}

		public void DoNovirtual()
		{
			Console.WriteLine($"{nameof(SomeBase)}.{nameof(DoNovirtual)}. this.GetType={this.GetType().Name}");
		}
	}

	class SomeChild1 : SomeBase
	{
		public override void DoVirtual()
		{
			Console.WriteLine($"{nameof(SomeChild1)}.{nameof(DoVirtual)}. this.GetType={this.GetType().Name}");
		}

		public void DoNovirtual()
		{
			Console.WriteLine($"{nameof(SomeChild1)}.{nameof(DoNovirtual)}. this.GetType={this.GetType().Name}");
		}
	}

}
