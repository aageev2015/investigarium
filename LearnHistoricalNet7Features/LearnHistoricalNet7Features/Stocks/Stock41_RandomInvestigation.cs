namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock41_RandomInvestigation
    // CountConformingBitmasks
    // https://app.codility.com/programmers/trainings/9/count_conforming_bitmasks/
    {

        private const uint bit30LimitMask = ((uint)1 << 30) - 1;

        public static void Do()
        {
            //Console.WriteLine(1 << (0 - 1));
            Console.WriteLine(solution3(1073741727, 1073741631, 1073741679));
            //Console.WriteLine(solution2(1073741727, 1073741727, 1073741727));

            //Console.WriteLine(solution2(~1 & (int)bit30LimitMask, ~2 & (int)bit30LimitMask, ~4 & (int)bit30LimitMask));
        }

        public static int solution3(int A, int B, int C)
        {
            int zerosA = 1, zerosB = 1, zerosC = 1;
            int zerosAorB = 1, zerosAorC = 1, zerosBorC = 1;
            int zerosAorBorC = 1;

            int AorB = A | B;
            int AorC = A | C;
            int BorC = B | C;
            int AorBorC = A | B | C;

            for (uint bit = 1; bit < (1 << 30); bit <<= 1)
            {
                if ((A & bit) == 0) zerosA <<= 1;
                if ((B & bit) == 0) zerosB <<= 1;
                if ((C & bit) == 0) zerosC <<= 1;
                if ((AorB & bit) == 0) zerosAorB <<= 1;
                if ((AorC & bit) == 0) zerosAorC <<= 1;
                if ((BorC & bit) == 0) zerosBorC <<= 1;
                if ((AorBorC & bit) == 0) zerosAorBorC <<= 1;
            }

            Console.WriteLine($"""
                {zerosA} + {zerosB} + {zerosC}
                - ({zerosAorB} + {zerosAorC} + {zerosBorC})
                + {zerosAorBorC}
                """);

            return zerosA + zerosB + zerosC
                - (zerosAorB + zerosAorC + zerosBorC)
                + zerosAorBorC;
        }

        public static int solution2(int A, int B, int C)
        {
            Console.WriteLine($"{A:B32}\n{B:B32}\n{C:B32}");
            int united0BitsNumber = 0;

            uint unitedVariantsOf0 = (uint)A & (uint)B & (uint)C;
            var log = () => Console.WriteLine($"{unitedVariantsOf0:B32}  - {united0BitsNumber}");
            log();
            for (uint bit = 1; bit < ((uint)1 << 30); bit <<= 1)
            {
                Console.WriteLine($"{bit:B32}");
                if ((unitedVariantsOf0 & bit) == 0) united0BitsNumber++;
                log();
            }

            if (united0BitsNumber <= 0)
            {
                return 0;
            }

            return 1 << united0BitsNumber;
        }


        public static int solution2_v1(int A, int B, int C)
        {
            Console.WriteLine($"{A:B32}\n{B:B32}\n{C:B32}");

            int unitedBitsNumber = 0;

            uint unitedVariants = ~(uint)A | ~(uint)B | ~(uint)C;
            unitedVariants &= bit30LimitMask;
            var log = () => Console.WriteLine($"{unitedVariants:B32}  - {unitedBitsNumber}");
            log();
            for (; unitedVariants != 0; unitedVariants >>= 1)
            {
                log();
                if ((unitedVariants & 1) == 1) unitedBitsNumber++;
            }

            if (unitedBitsNumber <= 0)
            {
                return 0;
            }

            return 1 << (unitedBitsNumber - 1);
        }


        public static void Do1()
        {
            Console.WriteLine($"-1       = {-1:B32}");
            Console.WriteLine($"0        = {0:B32}");
            Console.WriteLine($"max      = {int.MaxValue:B32}");
            Console.WriteLine($"min      = {int.MinValue:B32}");
            Console.WriteLine($"max+1    = {unchecked(int.MaxValue + 1):B32}");
            Console.WriteLine($"min-1    = {int.MinValue:B32}");
            Console.WriteLine($"max|min  = {(int.MaxValue | int.MinValue):B32}");
            Console.WriteLine($"min|1    = {(int.MinValue | 1):B32}");
            Console.WriteLine($"!min     = {(~int.MinValue):B32}");
            Console.WriteLine(solution1(561892));
        }

        public static int solution1(int N)
        {
            int maxLen = 0;
            int curLen = 0;

            var log = () => Console.WriteLine($"{N:B32}  - {curLen} \\ {maxLen}    {System.Numerics.BitOperations.PopCount((uint)N)}");

            if (N == 0)
            {
                return 0;
            }

            log();

            while ((N & 1) == 0)
            {
                N >>= 1;
                log();
            }

            N >>= 1;

            for (; N != 0; N >>= 1)
            {
                if ((N & 1) == 0)
                {
                    curLen++;
                }
                else
                {
                    if (curLen > maxLen)
                    {
                        maxLen = curLen;
                    }
                    curLen = 0;
                }
                log();
            }

            return maxLen;
        }

    }
}
