namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock36_IdentifierAllowedCharacters
    {

        public class @class() { }
        public class @public() { }
        public class theClass(string s) { public string S { get; } = s; }


        public static void Do()
        {
            var c1 = new theClass("®♠۞");
            c1 ??= new theClass("2");
            Console.WriteLine(c1.S);
        }

    }
}
