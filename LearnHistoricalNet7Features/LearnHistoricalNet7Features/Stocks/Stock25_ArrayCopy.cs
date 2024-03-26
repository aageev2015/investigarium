namespace LearnHistoricalNet7_8Features.Stocks
{

    public static class Stock25_ArrayCopy
    {


        public static void Do()
        {
            int[] array1 = [1, 2, 4, 7, 7, 0, 0, 0];
            int[] array2 = [50, 60, 80];
            array2.CopyTo(array1, array1.Length - array2.Length);
            Console.WriteLine(String.Join(',', array1));
        }

    }
}

