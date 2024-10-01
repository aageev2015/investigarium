namespace LearnHistoricalNet7_8Features.Stocks
{
    public static class Stock47_explicitConvert
    {

        public class Class1
        {
            public string Data { get; set; } = String.Empty;

            public Class1(string data) { Data = data; }

            //public static explicit operator Class1(Class2 source) => new Class1(source.Data.ToString());

            public static explicit operator Class2(Class1 source)
            {
                var result = Int32.Parse(source.Data);
                return new Class2(result);
            }
        }

        public class Class2
        {
            public int Data { get; set; }

            public Class2(int data) { Data = data; }

            public static explicit operator Class2(Class1 source)
            {
                var result = Int32.Parse(source.Data);
                return new Class2(result);
            }
        }

        public static void Do()
        {
            var v1 = new Class1("55");
            //Class2 v2 = (Class2)v1; //Compiler Error CS0457
        }

    }
}
