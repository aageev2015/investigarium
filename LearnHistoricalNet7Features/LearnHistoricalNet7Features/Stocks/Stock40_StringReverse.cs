using System.Text;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock40_StringReverse
    {
        // some were taken from https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string

        public static void Do()
        {
            var input = "abcdefg 12345";
            List<(string Title, Func<string, string> Func)> funcs = [
                (nameof(reverseByConcatenation), reverseByConcatenation),
                (nameof(reverseWithStringBuilder), reverseWithStringBuilder),
                (nameof(reverseWithEnumerableReverse), reverseWithEnumerableReverse),
                (nameof(reverseWithArrayReverse), reverseWithArrayReverse),
                (nameof(reverseWithSpan), reverseWithSpan),
                (nameof(reverseWithXor), reverseWithXor),
                (nameof(reverseWithSpanReverse), reverseWithSpanReverse),
            ];
            foreach (var item in funcs)
            {
                Console.WriteLine($"{item.Title} = {item.Func(input)}");
            }
        }


        private static string reverseByConcatenation(string input)
        {
            var result = string.Empty;
            var start = input.Length - 1;
            for (var i = start; i >= 0; i--)
            {
                result += input[i];
            }
            return result;
        }

        private static string reverseWithStringBuilder(string input)
        {
            var sb = new StringBuilder(input.Length);
            for (var i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        private static string reverseWithEnumerableReverse(string input)
        {
            return String.Join("", input.Reverse());
        }

        private static string reverseWithArrayReverse(string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }

        private static string reverseWithSpan(string input)
        {
            var len = input.Length;
            Span<char> chars = stackalloc char[len];
            len--;
            for (var i = 0; i <= len; i++)
            {
                chars[i] = input[len - i];
            }
            return chars.ToString();
        }

        private static string reverseWithXor(string s)
        {
            char[] charArray = s.ToCharArray();

            for (int low = 0, hi = s.Length - 1; low < hi; low++, hi--)
            {
                charArray[low] ^= charArray[hi];
                charArray[hi] ^= charArray[low];
                charArray[low] ^= charArray[hi];
            }

            return new string(charArray);
        }

        private static string reverseWithSpanReverse(string s)
        {
            return string.Create(s.Length, s, (spanChars, s) =>
            {
                s.AsSpan().CopyTo(spanChars);
                spanChars.Reverse();
            });
        }
    }
}
