using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHistoricalNet7_8Features.Tests
{
	internal static class RangeTests
	{
		public static void Test1()
		{
			int[] numbers = new[] { 0, 5, 10, 20, 30, 40, 50 };
			int amountToDrop = numbers.Length / 2;

			int[] rightHalf = numbers[amountToDrop..];
			Display(rightHalf);  // output: 30 40 50

			int[] rightHalf1 = numbers[^amountToDrop..];
			Display(rightHalf1);  // output: 30 40 50


			int[] leftHalf = numbers[..^amountToDrop];
			Display(leftHalf);  // output: 0 10 20

			int[] leftHalf2 = numbers[..amountToDrop];
			Display(leftHalf2);  // output: 0 10 20

			int[] all = numbers[..];
			Display(all);  // output: 0 10 20 30 40 50

			void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));
		}
	}
}
