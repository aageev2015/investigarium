using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHistoricalNet7_8Features.FeatureTry
{
	public static class EnumeratorFromArrayTricks
	{
		public static void Run(TextWriter log)
		{
			int[] arr = new int[10];
			for (var i = 0; i < arr.Length; i++) {
				arr[i] = i*100;
			}
			log.WriteLine(arr.GetType().FullName);

			log.WriteLine("first");
			var enumerator = arr.Cast<int>().GetEnumerator();
			logEnumerator(log, enumerator);

			arr[0] = 9999;

			log.WriteLine("second");
			logEnumerator(log, enumerator);
		}

		public static void logEnumerator<T>(TextWriter log, IEnumerator<T> enumerator)
		{
			enumerator.Reset();
			while (enumerator.MoveNext())
			{
				log.Write($"{enumerator.Current}, ");
			}
			log.WriteLine();
		}
	}
}
