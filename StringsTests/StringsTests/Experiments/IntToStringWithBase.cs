using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests.Experiments
{
	public class IntToStringWithBase : IExperiment
	{
		long testConv(Func<int, int, string> fun, int value, int digits, long avg) {
            long result = 0;
            for (long n = 0; n < avg; n++) {
                var sw = Stopwatch.StartNew();
                fun(value, digits);
                result += sw.ElapsedTicks;
            }
            Console.WriteLine((string)fun(value, digits));
            return result / (avg / 100);//for bigger output values
        }
        string IntToBinary(int value, int totalDigits) {
            char[] output = new char[totalDigits];
            int diff = sizeof(int) * 8 - totalDigits;
            for (int n = 0; n != totalDigits; ++n) {
                output[n] = (char)('0' + (char)((((uint)value << (n + diff))) >> (sizeof(int) * 8 - 1)));
            }
            return new string(output);
        }
        string Microsoft(int value, int totalDigits) {
            return Convert.ToString(value, toBase: 2).PadLeft(totalDigits, '0');
        }

		public void Run(int eCode = 0)
		{   /*
			int v = 123, it = 10000000;
            Console.WriteLine(testConv(IntToBinary, v, 10, it));
            Console.WriteLine(testConv(Microsoft, v, 10, it));
            */
            String a = "Rohatash Kumar";
            dynamic a1 = a;
            int b = a1;
		}
	}

}
