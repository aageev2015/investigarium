namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock44_RandomInvestigation
    // https://app.codility.com/????/
    {

        public static void Do()
        {
            testValue("89999999999999999999999999999999999999999");
            testValue("19999999999999999999999999999999999999999");
            testValue("89999999999999999999999999999999999999998");
            testValue("19999999999999999999999999999999999999998");

            for (int i = 2; i < 100000; i++)
            {
                int I = i - 1;
                int I10Sum = digit10Sum(I);
                string iResult = solution(i.ToString());
                int iResult10Sum = digit10Sum(iResult);
                int iResultInt = Int32.Parse(iResult);
                if (iResultInt >= i || I10Sum > iResult10Sum)
                {
                    Console.WriteLine($"{i} -> {I} (sum={I10Sum}). {iResult} (sum={iResult10Sum}) WRONG!");
                }
                else if (i <= 1000)
                {
                    //Console.WriteLine($"{i} -> {I} (sum={I10Sum}). {iResult} (sum={iResult10Sum})");
                }
            }
        }

        private static void testValue(string value)
        {
            string result = solution(value);
            int resultSum = digit10Sum(result);
            int valueSum = digit10Sum(value);
            Console.WriteLine($"{valueSum} -> {value}\n{resultSum} -> {result}");
            Console.WriteLine();
        }

        private const byte digit0 = (byte)'0';

        public static string solution(string S)
        {
            int len = S.Length;
            Span<char> bytes = (len <= 200) ? stackalloc char[len] : new char[len];

            bool allInnerAre9 = true;
            int lastIndex = len - 1;
            for (int i = 1; i < lastIndex; i++)
            {
                bytes[i] = '9';
                if (S[i] != '9')
                {
                    allInnerAre9 = false;
                }
            }

            if (allInnerAre9 && S[lastIndex] == '9')
            {
                bytes[0] = S[0];
                bytes[lastIndex] = '8';
            }
            else
            {
                bytes[lastIndex] = '9';
                bytes[0] = (char)(S[0] - 1);
                if (bytes[0] == '0')
                {
                    bytes = bytes.Slice(1);
                }
            }

            return bytes.ToString();
        }

        public static int digit10Sum(int value)
        {
            int sum = 0;

            for (; value > 0; value /= 10)
            {
                sum += value % 10;
            }

            return sum;
        }

        public static int digit10Sum(string value)
        {
            int sum = 0;

            for (var i = 0; i < value.Length; i++)
            {
                sum += (value[i] - digit0);
            }

            return sum;
        }

    }
}
