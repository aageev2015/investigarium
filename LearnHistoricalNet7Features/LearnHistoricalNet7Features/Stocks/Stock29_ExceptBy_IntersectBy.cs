using System.Runtime.CompilerServices;

namespace LearnHistoricalNet7_8Features.Stocks
{

    public static class Stock29_ExceptBy_IntersectBy
    {
        private record TestRecord(int Id, string Name);

        public static void Do()
        {
            List<TestRecord> commonData = [
                new TestRecord(1, "Jonson"),
                new TestRecord(2, "Baby"),
                new TestRecord(3, "Richard"),
                new TestRecord(4, "Todor"),
                new TestRecord(5, "Alice"),
                new TestRecord(6, "Troll"),
                new TestRecord(7, "Zorro"),
                new TestRecord(8, "Rabbit"),
                new TestRecord(9, "Keyboard"),
                new TestRecord(10, "Tron"),
                new TestRecord(11, "Zodd"),
                new TestRecord(12, "Astalavista"),
                new TestRecord(13, "data 1"),
                new TestRecord(14, "data 3"),
                new TestRecord(15, "data 4"),
                new TestRecord(16, "data 5"),
                new TestRecord(17, "data 6"),
                new TestRecord(18, "SomethingLast"),
            ];

            List<string> testData = ["Jonson", "Troll", " miss 1", " miss 2 ", "Astalavista", " miss 3", "SomethingLast"];

            CompareCases(
                from r in commonData
                where !testData.Contains(r.Name)
                select r
                ,
                commonData.ExceptBy(testData, r => r.Name)
            );

            CompareCases(
                from r in commonData
                where testData.Contains(r.Name)
                select r
                ,
                commonData.IntersectBy(testData, r => r.Name)
            );
        }

        private static void PrintResult(IEnumerable<TestRecord> data)
        {
            Console.WriteLine($"Output: {string.Join(", ", data.Select(r => r.Name).ToList())}");
        }

        private static void CompareCases(
            IEnumerable<TestRecord> case1data,
            IEnumerable<TestRecord> case2data,
            [CallerArgumentExpression(nameof(case1data))] string expression1 = "",
            [CallerArgumentExpression(nameof(case2data))] string expression2 = ""
        )
        {
            var result1 = case1data.ToList();
            Console.WriteLine("Case1:");
            Console.WriteLine(expression1);

            var result2 = case2data.ToList();
            Console.WriteLine("Case2:");
            Console.WriteLine(expression2);

            PrintResult(result1);
            PrintResult(result2);

            Console.WriteLine();
        }

    }
}

