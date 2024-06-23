using NUnit.Framework;
using System.Collections.Frozen;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock33_ReadonlyCollections
    {

        public static void Do()
        {
            List<int> l = [1, 5, 7];
            l.Add(8);
            l.Dump(nameof(l));

            var l2 = l.AsReadOnly();
            //l2[0] = 100; // CS0200;

            var l3 = l.ToFrozenDictionary(i => i);
            Assert.Catch<NotSupportedException>(() => l3.TryAdd(50, 50));
            l3.Dump(nameof(l3));

            var fd = FrozenDictionary<int, int>.Empty;
            Assert.Catch<NotSupportedException>(() => fd.TryAdd(1, 2));
            fd.Dump(nameof(fd));

        }

    }
}
