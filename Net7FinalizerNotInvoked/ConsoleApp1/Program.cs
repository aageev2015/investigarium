using System;
using System.Runtime.CompilerServices;

namespace ConsoleAppNetFramework48Works
{
	public class DispClassNet48 : IDisposable
	{
		public int Val { get; set; }

		public DispClassNet48 NextState { get; private set; }

		public DispClassNet48(int val, DispClassNet48 next = null)
		{
			Val = val;
			NextState = next;
			Console.WriteLine($"New {Val}");
		}

		public void Dispose()
		{
			NextState = null;
			Console.WriteLine($"Disposed {Val}");
		}

		[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
		~DispClassNet48()
		{
			Console.WriteLine($"Finalize {Val}. ");
		}
	}


	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Call 1");
			using (var v1 = new DispClassNet48(1))
			using (var v2 = new DispClassNet48(2, v1))
			{
				Console.WriteLine("Call 2");
			}
			Console.WriteLine("Call 3");
		}
	}
}
