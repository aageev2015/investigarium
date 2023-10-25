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
	public delegate void WriteMeDelegate();

	public class FunWithDelegates : IExperiment
	{

		public void Run(int eCode = 0)
		{
			var t = new ConcurrentBag<string> ();
			//Expression<Func<int>> e;

			Console.WriteLine("HashCode= {0}. {1} ", this.GetHashCode(), this.GetType().Name);

			WriteMeDelegate justDoIt;
			using (var v = new L1DoWork()) {
				ClassShowAllMembers(v);
				justDoIt = v.GetJustDoIt();
				justDoIt();
			}
		}

		public void ClassShowAllMembers(object obj)
		{
			var type = obj.GetType();
			Console.WriteLine($"----------- Members of instance {obj.GetHashCode()} of {type.Name} -------");
			foreach (var member in type.GetMembers())
			{
				Console.WriteLine($"{member.MemberType} {member.Name}");
			}
			Console.WriteLine($"----------- End -------");
		}
	}

	class L1DoWork: IDisposable
	{
		public StreamWriter EnclosedWriter { get; private set; }
		public FileStream EnclosedStream { get; private set; }

		public L1DoWork() {
			/*var fileName = Path.GetTempFileName();
			Console.WriteLine("HashCode= {0}. fileName={1}", this.GetHashCode(), fileName);
			EnclosedStream = File.Create(Path.GetTempFileName());			
			EnclosedWriter = new StreamWriter(EnclosedStream);

			EnclosedWriter.WriteLine($"just Something {new Random().Next()}");*/
		}

		public WriteMeDelegate GetJustDoIt()
		{
			Console.WriteLine("HashCode= {0}. {1} ", this.GetHashCode(), this.GetType().Name);

			var val1 = new SomeType(10);
			var val2 = new SomeType(20);
			var val3 = new SomeType(30);
			var val4 = new SomeType(40);

			var del1 = new WriteMeDelegate(val1.WriteMe);
			var del2 = new WriteMeDelegate(val2.WriteMe);
			var del3 = new WriteMeDelegate(val3.WriteMe);
			var del4 = new WriteMeDelegate(val4.WriteMe);
			var del5 = new WriteMeDelegate(() => Console.WriteLine("lambda"));

			var enclosedLocal = "local val";
			var enclosedLocalValDelegate = new WriteMeDelegate(delegate () {
				Console.WriteLine("HashCode= {0}. Hey! Im no method. enlosed to {1}", this.GetHashCode(), enclosedLocal);
			});

			var enclosedPropertyValDelegate = new WriteMeDelegate(delegate () {
				Console.WriteLine("HashCode= {0}. Hey! Im no method. enlosed to {1}. Length = {2}", this.GetHashCode(), EnclosedStream, EnclosedStream?.Length);
			});
			return (del1 + del2 + del3 + del4 + enclosedLocalValDelegate + enclosedPropertyValDelegate + del5);
		}

		public void Dispose()
		{
			Console.WriteLine("HashCode= {0}. {1} disposed", this.GetHashCode(), this.GetType().Name);
			/*EnclosedWriter.Close();
			EnclosedWriter.Dispose();
			EnclosedWriter = null;
			EnclosedStream.Close();
			EnclosedStream.Dispose();
			EnclosedStream = null;*/

		}
	}

	class SomeType
	{
		public int ValueProp1 { get; set; }
		public int Counter { get; private set; } = 0;
		public SomeType(int valueProp1)
		{
			ValueProp1 = valueProp1;
		}

		public void WriteMe()
		{
			Counter++;
			Console.WriteLine("HashCode= {0}, Value = {1}, Counter = {2}, ", this.GetHashCode(), ValueProp1, Counter);
		}
	}
}
