namespace LearnHistoricalNet7_8Features.Stocks
{
	public class Stock11_struct_fun
	{
		struct StrucValueDefaultConstructor
		{
			public int ValueInt { get; set; }
			public string ValueString { get; set; }
			public DateTime ValueDateTime { get; set; }

			public override string ToString()
			{
				return $"{ValueString ?? "<NULL>"} - {ValueDateTime}";
			}
		}

		struct StrucValueWithConstructor
		{
			public int ValueInt { get; set; } = 1;
			public string ValueString { get; set; } = "Empty";
			public DateTime ValueDateTime { get; set; } = DateTime.Now;

			public StrucValueWithConstructor()
			{
				Console.WriteLine($"StrucValueUserConstructor");
			}

			public override string ToString()
			{
				return $"{ValueString ?? "<NULL>"} - {ValueDateTime}";
			}
		}

		public static void Do()
		{
			var noConstructorArr = new StrucValueDefaultConstructor[10];
			noConstructorArr[0].ValueString = "abc1";
			var withConstructorArr = new StrucValueWithConstructor[10];
			withConstructorArr[0].ValueString = "abc2";

			var noConstructor = new StrucValueDefaultConstructor();
			var withConstructor = new StrucValueWithConstructor();


			Console.WriteLine($"{String.Join(',', noConstructorArr)}");
			Console.WriteLine($"{String.Join(',', withConstructorArr)}");
			Console.WriteLine($"{noConstructor}");
			Console.WriteLine($"{withConstructor}");
		}
	}
}

