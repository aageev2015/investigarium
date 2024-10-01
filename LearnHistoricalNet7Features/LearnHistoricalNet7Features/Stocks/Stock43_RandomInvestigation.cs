namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock43_RandomInvestigation
    // ParityDegree
    // https://app.codility.com/programmers/trainings/5/parity_degree/
    {

        public static void Do()
        {
            //solution1(23);
            //return;
            for (int i = 0; i < 1000; i++)
            {
                var A = solution1(i);
                Console.WriteLine($"{i}. sol({i:B32}) = {A} {1 << A:B32}");
            }
        }

        public static int solution1(int N)
        {
            int result = 0;
            int bit = 1;
            while (N > 0)
            {
                if ((N & bit) == bit)
                {
                    break;
                }
                result++;
                bit <<= 1;
            }
            return result;
        }

    }
}
