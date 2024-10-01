namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock42_RandomInvestigation
    // SparseBinaryDecomposition
    // https://app.codility.com/programmers/trainings/9/sparse_binary_decomposition/
    {

        public static void Do()
        {
            //solution1(23);
            //return;
            for (int i = 0; i < 1000; i++)
            {
                var A = solution1(i);
                var B = i - A;
                var isA = isSpare(A);
                var isB = isSpare(B);
                /*if (!isA || !isB)
                {*/
                Console.WriteLine($"{i}. sol({i:B32}) = {A} {A:B32} {isA} + {B} {B:B32} {isB}");
                //}
            }
        }

        public static int solution1(int N)
        {
            int result = 0;
            int prev = 0;
            int resultBit = 1;
            while (N > 0)
            {
                int cur = N & 1;
                if ((cur == 1) && (prev == 0))
                {
                    result += resultBit;
                    prev = 1;
                }
                else
                {
                    prev = 0;
                }
                resultBit <<= 1;
                N >>= 1;
            }
            return result;
        }

        public static bool isSpare(int N)
        {
            int prev = 0;
            while (N > 0)
            {
                int cur = N & 1;
                if (cur == 1)
                {
                    if ((prev == 1) || ((N & 2) == 2))
                    {
                        return false;
                    }
                }
                prev = cur;
                N >>= 1;
            }
            return true;
        }
    }
}
