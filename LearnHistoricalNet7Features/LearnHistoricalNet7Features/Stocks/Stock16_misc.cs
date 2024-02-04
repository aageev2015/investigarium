using System.Numerics;
using System.Runtime.CompilerServices;
using TheTupple = (int id, string name);

namespace LearnHistoricalNet7_8Features.Stocks
{
    public record class MyRec2(string Id);

    public static class Stock16_misc_ext
    {
        public static void AnyExt<T>(this T record, string msg)
        {
            Console.WriteLine($"AnyExt {msg}. {record}");
        }
        public static void AnyExt2(this MyRec2 record, string msg)
        {
            Console.WriteLine($"AnyExt2 {msg}. {record}");
        }
    }

    public class Stock16_misc
    {

        private record MyRecTest<T>(T int1, string Name)
        {
            public MyRecTest() : this(default, String.Empty) { }
        }
        private record MyRecTest2<T>(int int2) : MyRecTest<T>;

        public static void Do5()
        {
            var rec = new MyRecTest2<TheTupple>(5);
            //rec.int2 = 55;
            Console.WriteLine(rec);
        }

        public static void Do4()
        {
            MyRec2 rec = new("val");
            rec.AnyExt("haha");
        }

        private static void someMethod(int val, [CallerArgumentExpression("val")] string valExpression = null)
        {
            Console.WriteLine($"{valExpression}={val}");

        }

        public static void Do3()
        {
            someMethod(2 + 2);
            var a = 1;
            someMethod(5 * a);
            someMethod(Enumerable.Range(1, 5).Sum());
        }

        class TestAttrAttribute : Attribute { }
        record MyRec(string Id, int Value);

        public static void Do2()
        {
            MyRec obj = new(Id: "test", Value: 2);
            Console.WriteLine("test_Do_start");
            Console.WriteLine("test_Do_end");
            var f = [return: TestAttr] static (int x) => { return x; };
            Func<float> f1 = [return: TestAttr] () => { return 1; };
            string b = "test";
            var y = new Dictionary<string, int> { [b] = 2 };
            Console.WriteLine(y[b]);

            var t = new Func<int, int>[] { [TestAttr] (x) => 2 * x };
            Console.WriteLine(t[0](5));
        }

        public static void Do1()
        {
            var arr = Enumerable.Range(0, 65535 - 1).ToArray();

            Array.ForEach(arr, i => arr[i] += 1);
            //Array.ForEach(arr, Console.WriteLine);
            Console.WriteLine(arr[arr.Length - 1]);
        }


        public int SumVectorT(ReadOnlySpan<int> source)
        {
            int result = 0;

            Vector<int> vresult = Vector<int>.Zero;

            int i = 0;
            int lastBlockIndex = source.Length - (source.Length % Vector<int>.Count);

            while (i < lastBlockIndex)
            {
                vresult += new Vector<int>(source.Slice(i));
                i += Vector<int>.Count;
            }

            for (int n = 0; n < Vector<int>.Count; n++)
            {
                result += vresult[n];
            }

            while (i < source.Length)
            {
                result += source[i];
                i += 1;
            }

            return result;
        }

        private class _DisposeTest : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("internal dispose");
            }
        }
    }
}

