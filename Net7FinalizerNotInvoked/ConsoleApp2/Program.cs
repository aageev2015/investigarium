// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Call 1");
using (var v1 = new DispClassNet7(1))
using (var v2 = new DispClassNet7(2, v1))
{
	Console.WriteLine("Call 2");
}
Console.WriteLine("Call 3");

Console.WriteLine("System.GC.Collect start");
System.GC.Collect(System.GC.MaxGeneration, GCCollectionMode.Aggressive, blocking: true, compacting: true);
Console.WriteLine("System.GC.Collect done");
Console.WriteLine("System.GC.WaitForPendingFinalizers start");
System.GC.WaitForPendingFinalizers();
Console.WriteLine("System.GC.WaitForPendingFinalizers done");

public class DispClassNet7 : IDisposable
{
	public int Val { get; set; }

	public DispClassNet7? NextState { get; private set; }

	public DispClassNet7(int val, DispClassNet7? next = null)
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
	~DispClassNet7()
	{
		Console.WriteLine($"Finalize {Val}. " +
			$"Not called in any experiments for Net7. Supposed existance of some new conditions");
	}
}
