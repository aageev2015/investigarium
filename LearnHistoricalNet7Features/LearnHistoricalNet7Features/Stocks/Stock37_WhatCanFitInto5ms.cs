using System.Diagnostics;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock37_WhatCanFitInto5ms
    {

        public static void Do()
        {
            long nestedIterations = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds < 5)
            {
                for (int j = 0; j < 1000; j++)
                {
                    nestedIterations++;
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Total nested iterations: {nestedIterations:N0}");
        }
    }
}
