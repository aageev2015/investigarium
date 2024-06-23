using System.Runtime.CompilerServices;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock39_TwoEnumerators
    {

        public static void Do()
        {
            var a1 = new int[] { 1, 2 };
            System.Array a1AsArray = a1;
            Console.WriteLine("Arrays type test");
            Console.WriteLine(a1.GetType().FullName);
            Console.WriteLine(a1AsArray.GetType().FullName);
            Console.WriteLine(a1.GetType() == a1AsArray.GetType());

            List<int> list = [100, 200, 500, 55, 66, 77, 99, 150];
            IEnumerator<int> e1 = list.GetEnumerator();
            IEnumerator<int> e2 = list.GetEnumerator();

            Console.WriteLine("Example: " + string.Join(", ", list));

            Console.WriteLine("get new");
            Console.WriteLine();

            Console.WriteLine("mix 1");
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e2);
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e2);
            MoveNextLoggged(in e2);
            Console.WriteLine();

            Console.WriteLine("while loop e1");
            while (e1.MoveNext()) Console.WriteLine(e1.Current);
            Console.WriteLine();

            Console.WriteLine("while loop e2");
            while (e2.MoveNext()) Console.WriteLine(e2.Current);

            Console.WriteLine("mix 2");
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e2);
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e2);
            Console.WriteLine();

            Console.WriteLine("Reset both");
            e1.Reset();
            e2.Reset();
            Console.WriteLine();

            Console.WriteLine("mix 3");
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e1);
            MoveNextLoggged(in e2);
            MoveNextLoggged(in e2);
            MoveNextLoggged(in e2);
            Console.WriteLine();

        }

        private static bool MoveNextLoggged<T>(in IEnumerator<T> e,
            [CallerArgumentExpression("e")] string expression = "")
        {
            if (e.MoveNext())
            {
                Console.WriteLine($"fetched {expression}. Current = {e.Current}");
                return true;
            }
            else
            {
                Console.WriteLine($"End of enumerator {expression}");
                return false;
            }
        }
    }
}
