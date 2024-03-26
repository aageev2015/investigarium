using System.Numerics;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock22_FibonacciDigits
    {

        public static void Do()
        {
            var lengths = GetFibonacciDigitsLengs(10000 + 2);
            Console.WriteLine($"avg = {lengths.Where(v => v != 0).Average()}");
            Console.WriteLine(string.Join(", ", lengths.Select(i => i.ToString()).ToList()));
        }

        private static int[] GetFibonacciDigitsLengs(int index)
        {
            if (index >= 0 && index <= 1)
            {
                return [0, 1];
            }

            BigInteger val0 = 1;
            BigInteger val1 = 1;
            BigInteger tmp;
            var result = new int[(int)(1 + Math.Ceiling(index / 4.75))];

            for (var i = 2; i < index; i++)
            {
                tmp = val1;
                val1 = val0 + val1;
                val0 = tmp;
                result[val1.ToString().Length]++;
            }

            return result;
        }
    }
}

