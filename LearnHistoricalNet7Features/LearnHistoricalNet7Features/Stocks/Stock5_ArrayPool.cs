using System.Buffers;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public class Stock5_ArrayPool
    {

        static Stock5_ArrayPool()
        {
            pause("Load static");
        }

        public unsafe static void Do()
        {
            var pool = ArrayPool<int>.Shared;

            pause("Rent arr1");
            int[] arr1 = pool.Rent(3);
            fixed (int* p = &arr1[0])
            {
                Console.WriteLine((int)p);
            }
            for (var i = 1; i < 3; i++)
            {
                arr1[i] = i;
            }

            pause("Rent arr2");
            var arr2 = pool.Rent(5);
            fixed (int* p = &arr2[0])
            {
                Console.WriteLine((int)p);
            }
            for (var i = 1; i < 5; i++)
            {
                arr2[i] = i * 10;
            }


            pause("Return arr1,arr2");
            pool.Return(arr2);
            pool.Return(arr1);

            pause("Rent arr3");
            var arr3 = pool.Rent(7);
            fixed (int* p = &arr3[0])
            {
                Console.WriteLine((int)p);
            }
            pause("Return arr3");
            pool.Return(arr3);

            pause("Rent arrs[50]");
            int[][] arrs = new int[100][];
            for (var i = 0; i < 50; i++)
            {
                var arr = pool.Rent(10);
                arrs[i] = arr;
                for (var j = 0; j < 10; j++)
                {
                    arr[j] = i * 100 + j;
                }
            }

            pause("Rent arr4");
            var arr4 = pool.Rent(10);
            pause("Rent arr5");
            var arr5 = pool.Rent(10);

            pause("Return arr[50]");
            for (var i = 0; i < 50; i++)
            {
                pool.Return(arrs[i]);
            }
            pause("Return arr4");
            pool.Return(arr4);
            pause("Return arr5");
            pool.Return(arr5);
        }

        private static void pause(string title, bool doPause = true)
        {
            Console.WriteLine(title);
            if (doPause)
            {
                Console.ReadLine();
            }
        }
    }
}

