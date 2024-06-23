//https://www.linkedin.com/posts/davidcallan_use-stringsyntax-attribute-to-%3F%3F%3F%3F-%3F-activity-7196117097708486659-w-mL
//https://github.com/dotnet/roslyn/issues/60593
//https://github.com/dotnet/runtime/issues/65634
// not fully clear

using System.Diagnostics.CodeAnalysis;

namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock35_StringSyntax
    {

        private enum TestEnum
        {
            One, Two, Three
        }

        private static int TestingDTO(
            [StringSyntax(StringSyntaxAttribute.CompositeFormat)]
            string data, params object[] args)
        {
            Console.WriteLine(data);
            return data.Length;
        }

        public static void Do()
        {
            Console.WriteLine(TestingDTO("{0} {1} asdf", "test", 1));
        }
    }

}
