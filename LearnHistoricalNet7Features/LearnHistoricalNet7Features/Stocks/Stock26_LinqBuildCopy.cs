using System.Runtime.CompilerServices;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public static class Stock26_LinqBuildCopy
    {


        public static void Do()
        {
            int[] array1 = [1, 2, 4, 7, 7, 111, 22, 3];
            var enum1 = (from v in array1 select Mult(v));
            var query1 = enum1.AsQueryable();
            var query2 = query1.Where(v => v < 7);
            //var query3 = query2.Where(v => v < 3);
            Console.WriteLine("run mat1");
            var materialized1 = query1.ToArray();
            Console.WriteLine("\nrun mat2");
            var materialized2 = query2.ToArray();
            Console.WriteLine("run done\n");

            LogObject(enum1);
            LogObject(query1);
            LogObject(query2);
            LogObject(materialized1);
            LogObject(materialized2);
        }

        public static void LogObject(object o, [CallerArgumentExpression("o")] string o_expression = "")
        {
            Console.WriteLine($"""
                {o_expression}: {o.GetHashCode()}
                Type: {o.GetType().FullName}
            """);
        }

        public static void LogObject<T>(IEnumerable<T> o, [CallerArgumentExpression("o")] string o_expression = "")
        {
            Console.WriteLine($"""
                {o_expression}: {o.GetHashCode()}
                Type: {o.GetType().FullName}
                Value: {String.Join(',', o)}
                
                """);
        }

        public static int Mult(int v)
        {
            Console.WriteLine("Mult");

            return v * 2;
        }


    }
}

