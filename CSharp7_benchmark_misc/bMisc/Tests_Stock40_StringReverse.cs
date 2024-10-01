// Not finished
using System.Text;

namespace bMisc
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [RankColumn]
    public class Tests_Stock40_StringReverse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Params("", "+3(866) 000-00-00",
            "12312312343458578asdasdasdadsassd asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd " +
            "455849045754843fdjcvndkdjfjgjjvj349 8394387349vjndkcvndkf 12312312343458578asdasdasdadsassd " +
            "asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd 455849045754843fdjcvndkdjfjgjjvj349 " +
            "12312312343458578asdasdasdadsassd asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd " +
            "455849045754843fdjcvndkdjfjgjjvj349 8394387349vjndkcvndkf 12312312343458578asdasdasdadsassd " +
            "asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd 455849045754843fdjcvndkdjfjgjjvj349 " +
            "12312312343458578asdasdasdadsassd asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd " +
            "455849045754843fdjcvndkdjfjgjjvj349 8394387349vjndkcvndkf 12312312343458578asdasdasdadsassd " +
            "asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd 455849045754843fdjcvndkdjfjgjjvj349 " +
            "12312312343458578asdasdasdadsassd asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd " +
            "455849045754843fdjcvndkdjfjgjjvj349 8394387349vjndkcvndkf 12312312343458578asdasdasdadsassd " +
            "asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd 455849045754843fdjcvndkdjfjgjjvj349 " +
            "455849045754843fdjcvndkdjfjgjjvj349 8394387349vjndkcvndkf 12312312343458578asdasdasdadsassd " +
            "asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd 455849045754843fdjcvndkdjfjgjjvj349 " +
            "12312312343458578asdasdasdadsassd asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd " +
            "455849045754843fdjcvndkdjfjgjjvj349 8394387349vjndkcvndkf 12312312343458578asdasdasdadsassd " +
            "asdadasd asd asda sda sdgmlkadslkvfgkjfgkjgfkjsdkjsd 455849045754843fdjcvndkdjfjgjjvj349 "
            )]
        public string Input { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        [GlobalSetup]
        public void GlobalSetup()
        {
        }


        [Benchmark(Baseline = true)]
        public string reverseByConcatenation()
        {
            var input = Input;
            var result = string.Empty;
            var start = input.Length - 1;
            for (var i = start; i >= 0; i--)
            {
                result += input[i];
            }
            return result;
        }

        [Benchmark]
        public string reverseWithStringBuilder()
        {
            var input = Input;
            var sb = new StringBuilder(input.Length);
            for (var i = Input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string reverseWithEnumerableReverse()
        {
            var input = Input;
            return String.Join("", input.Reverse());
        }

        [Benchmark]
        public string reverseWithArrayReverse()
        {
            var input = Input;
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new String(charArray);
        }

        [Benchmark]
        public string reverseWithSpan()
        {
            var input = Input;
            var len = input.Length;
            Span<char> chars = stackalloc char[len];
            len--;
            for (var i = 0; i <= len; i++)
            {
                chars[i] = input[len - i];
            }
            return chars.ToString();
        }

        [Benchmark]
        public string reverseWithXor()
        {
            var input = Input;
            char[] charArray = input.ToCharArray();

            for (int low = 0, hi = input.Length - 1; low < hi; low++, hi--)
            {
                charArray[low] ^= charArray[hi];
                charArray[hi] ^= charArray[low];
                charArray[low] ^= charArray[hi];
            }

            return new string(charArray);
        }

        [Benchmark]
        public string reverseWithSpanReverse()
        {
            var input = Input;
            return string.Create(input.Length, input, (spanChars, s) =>
            {
                s.AsSpan().CopyTo(spanChars);
                spanChars.Reverse();
            });
        }

    }
}