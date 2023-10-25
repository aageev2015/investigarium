// motivation. What is faster: use switch(scan-like) or dictionary with it's hashmap key (seek-like)
// notice: switch - hardcoded compiletime. Dictionary - flexible runtime

using System.Reflection.Emit;

namespace bMisc
{
	[KeepBenchmarkFiles]
	[MemoryDiagnoser]
	[RankColumn]
	public class TestsSwitchVsDictionary
	{
		[Params(5, 20, 100, 500)]
		public int Count { get; set; }


		public const string PrefixKind = "TheKeyN_";
		public Dictionary<string, int> Dictionary { get; set; }

		[GlobalSetup]
		public void GlobalSetup()
		{
			Dictionary = new Dictionary<string, int>(Count);
			foreach (var i in Enumerable.Range(1, Count))
			{
				Dictionary.Add(PrefixKind + i.ToString(), i);
			}
		}


		[Benchmark(Baseline = true)]
		public int tInt1Loop()
		{
			return 0;
		}

		private int switchExample(string s)
		{
			switch (s)
			{
				case "TheKeyN_1":
					return 1;
				case "TheKeyN_2":
					return 2;
				case "TheKeyN_3":
					return 3;
			}
			return -1;
		}
		private Func<string, int> GenSwitchMethod(int count)
		{
			var method = new DynamicMethod("bigSwitch", typeof(int), new[] { typeof(string) });
			var il = method.GetILGenerator();
			var result = il.DeclareLocal(typeof(int));
			return (Func<string, int>)method.CreateDelegate(typeof(Func<string, int>));
		}

	}

}