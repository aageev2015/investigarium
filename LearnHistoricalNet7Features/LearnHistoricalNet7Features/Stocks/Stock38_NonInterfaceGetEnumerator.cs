namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock38_NonInterfaceGetEnumerator
    {

        private class TestClass
        {
            public IEnumerator<int> GetEnumerator()
            {
                return Enumerable.Range(1, 10).GetEnumerator();
            }
        }

        public static void Do()
        {
            var foreachable = new TestClass();
            foreach (var i in foreachable)
            {
                Console.WriteLine(i);
            }
        }
    }
}
