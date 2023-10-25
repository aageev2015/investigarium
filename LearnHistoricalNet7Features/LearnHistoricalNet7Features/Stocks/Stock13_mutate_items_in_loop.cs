namespace LearnHistoricalNet7_8Features.Stocks
{
	public class Stock13_mutate_items_in_loop
	{

		public static void Do()
		{
			arrayResize();
			listItemsChange();
		}

		private static void listItemsChange()
		{
			Console.WriteLine("--------");
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name ??
				"System.Reflection.MethodBase.GetCurrentMethod() == null");


			Console.WriteLine("for");
			var list = Enumerable.Range(100, 10).ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
				if (i == 3)
				{
					list.Add(10000);
				}
			}

			Console.WriteLine("foreach");
			try
			{
				foreach (var val in list)
				{
					Console.WriteLine(val);
					if (val == 103)
					{
						list.Add(10100);
					}
				}
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine($"{e}: {e.Message}");
			}
		}

		private static void arrayResize()
		{
			Console.WriteLine("--------");
			Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name ??
				"System.Reflection.MethodBase.GetCurrentMethod() == null");

			int[] arr = Enumerable.Range(100, 10).ToArray();
			ref int refItem = ref arr[0];
			for (int i = 0; i < arr.Length; i++)
			{
				if (i % 2 == 0)
				{
					refItem = ref GetItemByRef(arr, i);
					refItem *= 10;
				}
				Console.WriteLine($"{i} - {arr[i]}");
				if (i == 3)
				{

					Array.Resize(ref arr, 8);
				}
				if (i == 6)
				{

					Array.Resize(ref arr, 15);
				}
			}

			Array.Resize(ref arr, 1);
			refItem = 123123;
			Console.WriteLine(refItem);
		}

		private static ref int GetItemByRef(int[] arr, int i)
		{
			return ref arr[i];
		}
	}
}

