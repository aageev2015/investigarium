using System.Collections;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock48_DuckTyping
    {

        private class EnumerableDuckType
        {
            private class EnumerableDuckTypeEnumerator : IEnumerator<int>
            {
                private int _current = 0;

                public int Current => _current;

                object IEnumerator.Current => _current;

                public void Dispose() { }
                public bool MoveNext()
                {
                    _current++;
                    return _current < 5;
                }

                public void Reset()
                {
                    _current = 0;
                }
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new EnumerableDuckTypeEnumerator();
            }
        }

        private class DisposableDuckType
        {
            void Dispose()
            {
                Console.WriteLine("Disposed");
            }
        }

        public static void Do()
        {
            EnumerableDuckType e = new();
            foreach (int i in e)
            {
                Console.WriteLine(i);
            }

            using (DisposableDuckType disp = new())
            {
            }

        }

    }
}
