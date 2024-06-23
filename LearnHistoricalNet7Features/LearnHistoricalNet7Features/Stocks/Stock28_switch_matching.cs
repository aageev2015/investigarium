namespace LearnHistoricalNet7_8Features.Stocks
{

    public static class Stock28_switch_matching
    {


        public static void Do()
        {
            PropertyPatterMatch_DoesConditionInstancesOrSyntax();
        }

        public record TestingData(string Name, int[] Data) { }
        public static void PropertyPatterMatch_DoesConditionInstancesOrSyntax()
        {   /*
             * Test conclusion: switch pattern matching by property is pure syntax thing. 
             * Require constants for matching data
             * Improssible to provide anything preallocated instanses as matching data. CS9135
             */

            TestingData testingInstance = new("Data name 1", [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100]);
            var (name1, arr1) = testingInstance;
            Console.WriteLine(name1);

            long memory1 = GC.GetTotalAllocatedBytes(true);
            int result = testingInstance switch
            {
                {
                    Name: "Data name 1",
                    Data: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100]
                } => 1,
                _ => 2
            };
            long memory2 = GC.GetTotalAllocatedBytes(true);
            Console.WriteLine($"1. Memory delta {memory2 - memory1}. Result {result}");

            memory1 = GC.GetTotalAllocatedBytes(true);
            result = testingInstance switch
            {
                { Name: "Data name 1", Data: [] }
                    => 1,
                _ => 2
            };
            memory2 = GC.GetTotalAllocatedBytes(true);
            Console.WriteLine($"2. Memory delta {memory2 - memory1}. Result {result}");

            /*
            memory1 = GC.GetTotalAllocatedBytes(true);
            TestingData theObj = new ("Data name 1", [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100]);
            result = testingInstance switch
            {
                theObj => 1, // CS9135
                _ => 2
            };
            memory2 = GC.GetTotalAllocatedBytes(true);
            Console.WriteLine($"3. Memory delta {memory2 - memory1}. Result {result}");
            */

            /*
            int[] inHeapArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100];
            memory1 = GC.GetTotalAllocatedBytes(true);
            result = testingInstance switch
            {
                {
                    Name: "Data name 1",
                    Data: inHeapArray // CS9135
                } => 1,
                _ => 2
            };
            memory2 = GC.GetTotalAllocatedBytes(true);
            Console.WriteLine($"4. Memory delta {memory2 - memory1}. Result {result}");
            */
        }

    }
}

