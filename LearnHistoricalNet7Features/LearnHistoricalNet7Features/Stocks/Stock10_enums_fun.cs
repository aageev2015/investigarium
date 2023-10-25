namespace LearnHistoricalNet7_8Features.Stocks
{
	public class Stock10_enums_fun
	{
		enum MyEnum
		{
			Item1 = 1,
			Item2 = 1,
			Item3,
			Item4 = 50,
			Item5,
			Item6
		}

		public static void Do()
		{
			var eType = typeof(MyEnum);
			foreach (var item in Enum.GetValues(eType))
			{
				Console.WriteLine($"{item} = {(int)item}");
			}
		}
	}
}

