// not finished
// investigate codepage

namespace LearnHistoricalNet7_8Features.Stocks
{
	public class Stock15_gen_case_code
	{
		private delegate int GenerateInStringOutInt(string s);


		public static void Do()
		{
			bool? val = true;
			if (val == true)
			{
				Console.WriteLine("ok1");
			}
			val = null;
			if (val == true)
			{
				Console.WriteLine("ok2 TRUE");
			}

			if (val == false)
			{
				Console.WriteLine("ok2 FALSE");
			}

			if (val == null)
			{
				Console.WriteLine("ok2 NULL");
			}
		}


		public static void GenMethodSwitchInStringOutInt(string itemPrefix)
		{


			/*	string methodBody =
		   @"
	switch(s) {
		case ""Key1"": return 1;
		case ""Key2"": return 2;
		case ""Key3"": return 3;
	}
	return -1;
	";


				Type[] parameterTypes = { typeof(string) };

				DynamicMethod dm = new DynamicMethod("SwitchInStringOutInt",
										   typeof(int), parameterTypes,
										   this.GetType(),
										   methodBody,
						CodeDomProvider.CreateProvider("CSharp"));





				delAdd AddMethod = dm.CreateDelegate(typeof(delAdd));

				int Result = AddMethod(10, 20);*/
		}

	}
}

