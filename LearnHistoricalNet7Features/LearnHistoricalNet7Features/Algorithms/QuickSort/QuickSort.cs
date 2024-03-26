namespace LearnHistoricalNet7n8Features.Algorithms.QuickSort
{
    public static class QuickSortTest
    {
        public static void Do()
        {

            Rec[] arr = { new Rec(5, "test1"), new Rec(2, "test2"), new Rec(12, "test3"), new Rec(9, "test4") };
            Console.WriteLine(String.Join(',', arr.Select(v => v.Name)));
            var arr2 = TestArrCopy(arr);
            arr2[0] = arr[0] with { Name = arr[0].Name + "Modif1" };
            Console.WriteLine(String.Join(',', arr2.Select(v => v.Name)));

            var objArr = new Class1[] { new Class1(5, "CLtest1"), new Class1(2, "CLtest2"), new Class1(12, "CLtest3"), new Class1(9, "CLtest4") };
            var objArr2 = (Class1[])objArr.Clone();
            Console.WriteLine("objArr    " + String.Join(',', objArr.Select(v => v.Name)));
            Console.WriteLine("objArr2    " + String.Join(',', objArr2.Select(v => v.Name)));

            var arrRec2 = new RecStruct[4];
            Console.WriteLine("arrRec2    " + String.Join(',', arrRec2.Select(v => v.Name)));


            /*
            SortExampleAndLog([]);
            SortExampleAndLog([0]);
            SortExampleAndLog([1, 2, 3]);
            SortExampleAndLog([4, 3, 2, 1]);
            SortExampleAndLog([99, 30, 220, 10, 1, 20, 1000]);
            SortExampleAndLog([5, 4, 10, 9, 15]);
            */
        }

        private record Rec(int Id, string Name);
        private record struct RecStruct(int Id, string Name);
        private class Class1(int Id, string Name)
        {
            public int Id { get; } = Id;
            public string Name { get; } = Name;
        }

        private static T[] TestArrCopy<T>(T[] array)
        {
            T[] copy = new T[array.Length];
            Array.Copy(array, copy, array.Length);
            return copy;
        }

        private static void SortExampleAndLog(int[] arr)
        {
            var copyArr = new int[arr.Length];
            Array.Copy(arr, copyArr, arr.Length);
            QuickSort(arr);
            Console.WriteLine(String.Join(',', arr));
        }

        private static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var partIndex = Partition(arr, start, end);
            QuickSort(arr, start, partIndex - 1);
            QuickSort(arr, partIndex + 1, end);
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int j = start - 1;
            int tmp;
            for (var i = start; i <= end; i++)
            {
                if (arr[i] < pivot)
                {
                    j++;
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
            j++;
            arr[end] = arr[j];
            arr[j] = pivot;
            return j;
        }
    }
}
