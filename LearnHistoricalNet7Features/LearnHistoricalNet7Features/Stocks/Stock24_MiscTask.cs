namespace LearnHistoricalNet7_8Features.Stocks
{

    public static class Stock24_MiscTask
    {


        public static void Do()
        {
            int[] input = //new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 8 };
            new int[] { 540, 790, 976, 49, 128, 548, 272, 367, 239, 623, 493, 398, 81, 441, 875, 110, 462, 853, 0, 37, 926, 675, 496, 683, 850, 674, 96, 853, 710, 34, 861, 456, 181, 413, 823, 686, 675, 275, 209, 666, 928, 663, 592, 243, 969, 901, 304, 297, 404, 269, 611, 128, 262, 1, 905, 270, 777, 297, 578, 276, 413, 872, 33, 7, 115, 850, 619, 40, 920, 393, 387, 324, 685, 393, 743, 898, 394, 56, 514, 264, 394, 515, 413, 177, 737, 922, 860, 766, 850, 245, 221, 579, 474, 969, 694, 53, 402, 612, 848, 395 };
            Console.WriteLine(calcViaHashSet(input));
            Console.WriteLine(calcViaDictionary(input));
            Console.WriteLine(calcViaLinq(input));
            Console.WriteLine(calcViaPresort(input));
        }

        public static int calcViaHashSet(int[] input)
        {
            var len = input.Length;
            if (len == 0)
            {
                throw new Exception("Not found");
            }

            HashSet<int> duplicated = new HashSet<int>(len);
            HashSet<int> singles = new HashSet<int>(len);
            foreach (int candidate in input)
            {
                if (duplicated.Contains(candidate))
                {
                    continue;
                }
                if (singles.Contains(candidate))
                {
                    duplicated.Add(candidate);
                    singles.Remove(candidate);
                    continue;
                }
                singles.Add(candidate);
            }
            if (singles.Count == 0)
            {
                throw new Exception("Not found!!");
            }
            return singles.First();
        }

        public static int calcViaDictionary(int[] input)
        {
            var len = input.Length;
            if (len == 0)
            {
                throw new Exception("Not found");
            }

            var counts = new Dictionary<int, int>(len);
            foreach (int candidate in input)
            {
                if (counts.ContainsKey(candidate))
                {
                    counts[candidate]++;
                }
                else
                {
                    counts.Add(candidate, 1);
                }

            }
            foreach (var pair in counts)
            {
                if (pair.Value == 1)
                {
                    return pair.Key;
                }
            }
            throw new Exception("Not found!!");
        }

        public static int calcViaLinq(int[] input)
        {
            var len = input.Length;
            if (len == 0)
            {
                throw new Exception("Not found!!");
            }

            var query = from val in input
                        group val by val into val2
                        where val2.Count() == 1
                        select val2.Key;
            var first = query.Take(1).ToArray();
            if (first.Length == 0)
            {
                throw new Exception("Not found!!");
            }
            return first[0];
        }

        public static int calcViaPresort(int[] input)
        {
            var len = input.Length;
            if (len == 0)
            {
                throw new Exception("Not found!!");
            }
            if (len == 1)
            {
                return input[0];
            }

            int[] sorted = new int[input.Length];
            input.CopyTo(sorted, 0);
            Array.Sort(sorted);

            if (sorted[0] != sorted[1])
            {
                return input[0];
            }
            else if (len == 2)
            {
                throw new Exception("Not found!!");
            }

            int prev = sorted[0];
            int cur;
            for (var i = 1; i < len - 1; i++)
            {
                cur = sorted[i];
                if (prev != cur && cur != sorted[i + 1])
                {
                    return cur;
                }
                prev = cur;
            }

            cur = sorted.Last();
            if (cur != prev)
            {
                return cur;
            }

            throw new Exception("Not found!!");
        }

    }


}

