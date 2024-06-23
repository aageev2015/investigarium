namespace LearnHistoricalNet7_8Features.Stocks
{

    public static class Stock27_inline_array
    {

        public static void Do()
        {
            AnItem<int> inlineArray = new AnItem<int>();
            for (int i = 0; i < 100; i++)
            {
                inlineArray[i] = i * 2;
            }
            foreach (int i in inlineArray)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(typeof(TheThing1).Name);
        }

        [System.Runtime.CompilerServices.InlineArray(100)]
        public struct AnItem<T>
        {
            private T _item;
        }

        public record TheThing1(int Value)
        {
            public int Value { get; set; } = Value;
        }
    }
}

