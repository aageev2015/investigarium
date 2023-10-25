using System.Runtime.CompilerServices;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public class Stock7_SkipLocalInit
    {

        public static void Do()
        {
            TestMethodNoInit(2);
            TestMethodNoInit(4);
            TestMethodNoInit(10);
        }

        [SkipLocalsInit]
        public static int TestMethodNoInit(int val2)
        {
            Console.WriteLine($"start for {val2}");
            Span<int> arrSpan = stackalloc int[5];
            Console.WriteLine($"Before init: {string.Join(',', arrSpan.ToArray())}");
            for (int i = 0; i < arrSpan.Length; i++)
            {
                arrSpan[i] = i * val2;
            }
            Console.WriteLine($"After init: {string.Join(',', arrSpan.ToArray())}");
            int sum = 0;
            for (int i = 0; i < arrSpan.Length; i++)
            {
                sum += arrSpan[i];
            }
            return sum;
        }



    }
}

