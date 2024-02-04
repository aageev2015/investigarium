using System.Diagnostics;
using System.Numerics;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public class Stock18_BigInteger
    {

        public static void Do()
        {
            BigInteger b1 = int.MaxValue;
            Console.WriteLine(b1);
            b1++;
            Console.WriteLine(b1);
            b1 *= 2;
            Console.WriteLine(b1);
            b1 *= b1;
            Console.WriteLine(b1);
            b1 *= b1;
            Console.WriteLine(b1);
            b1 *= b1;
            Console.WriteLine(b1);

            BigInteger b2 = int.MaxValue;
            b2 ^= 2;
            Console.WriteLine(b2);

            Console.WriteLine($"mem = {GC.GetTotalMemory(true)}");
            Console.WriteLine();
            Parallel.For(1, 10, (val) =>
            {
                Stopwatch st = new();
                st.Start();
                var fibVal = GenerateFibonacci(1000);
                Console.WriteLine($"{val}. time = {st.ElapsedMilliseconds}; val = {fibVal.GetByteCount()}");
                Console.WriteLine($"        mem = {GC.GetTotalMemory(false)}");
                st.Stop();
            });
            Console.WriteLine($"mem = {GC.GetTotalMemory(false)}");
            Console.WriteLine($"mem = {GC.GetTotalMemory(true)}");
        }

        private static BigInteger GenerateFibonacci(int index)
        {
            if (index >= 0 && index <= 1)
            {
                return index;
            }

            BigInteger val0 = 1;
            BigInteger val1 = 1;
            BigInteger tmp;

            for (var i = 2; i < index; i++)
            {
                tmp = val1;
                val1 = val0 + val1;
                val0 = tmp;
            }

            return val1;
        }
    }
}

