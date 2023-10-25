// not finished
// investigate codepage

using System.Globalization;
using System.Text;

namespace LearnHistoricalNet7_8Features.Stocks
{
	public class Stock14_strings_chars
	{

		static readonly string tempFileName = Path.Combine(Path.GetTempPath(), nameof(Stock14_strings_chars) + @".txt");

		public static void Do()
		{
			Console.WriteLine(tempFileName);

			var s = "éa \u03C0";
			Console.WriteLine("{0,6}", s);
			AppenToFile(s);
			AppenToFile(string.Format("\t\t\t{0,6}", "\u0065\u0301"));

			Console.WriteLine(s.Length);
			Console.WriteLine(new StringInfo(s).LengthInTextElements);

			char c1 = s[0];
			char c2 = s[1];
			char c3 = s[2];
			char c4 = s[s.Length - 1];
			Console.WriteLine("{0,6} {1,6} {2,6} {3,6}", c1, c2, c3, c4);

			var cCarr = s.ToCharArray();
			c1 = cCarr[0];
			c2 = cCarr[1];
			c3 = cCarr[2];
			c4 = cCarr[cCarr.Length - 1];
			Console.WriteLine("{0,6} {1,6} {2,6} {3,6}", c1, c2, c3, c4);

			var en = System.Globalization.StringInfo.GetTextElementEnumerator(s);
			en.MoveNext();
			var s1 = en.GetTextElement();
			en.MoveNext();
			var s2 = en.GetTextElement();
			en.MoveNext();
			var s3 = en.GetTextElement();
			string? s4 = null;
			while (en.MoveNext())
			{
				s4 = en.GetTextElement();
			}
			Console.WriteLine("{0,6} {1,6} {2,6} {3,6}", s1, s2, s3, s4);

			s1 = s.Substring(0, 1);
			s2 = s.Substring(1, 1);
			s3 = s.Substring(2, 1);
			s4 = s.Substring(s.Length - 1, 1);
			Console.WriteLine("{0,6} {1,6} {2,6} {3,6}", s1, s2, s3, s4);

			Console.WriteLine("Console.OutputEncoding tests");
			var encodings = new Encoding[] {
				Encoding.ASCII,
				Encoding.UTF8,
				Encoding.Latin1,
				Encoding.Unicode,
				Encoding.BigEndianUnicode
			};
			foreach (var encoding in encodings)
			{
				WriteSafeWithEncoding("a", encoding);
				WriteSafeWithEncoding("é", encoding);
				WriteSafeWithEncoding("\u03C0", encoding);

			}
		}

		static void AppenToFile(string s)
		{
			using (var w = new StreamWriter(tempFileName, true))
			{
				w.WriteLine(s);
			}
		}

		static void WriteSafeWithEncoding(string s, System.Text.Encoding encoding)
		{
			Console.WriteLine($"============\ndefault way {encoding.EncodingName} {s}");

			var encodingSaved = Console.OutputEncoding;
			try
			{
				Console.OutputEncoding = System.Text.Encoding.BigEndianUnicode;
				Console.WriteLine(s);
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.GetType().Name}: {e}");
			}
			Console.OutputEncoding = encodingSaved;

			Console.WriteLine($"SetOut(writer)");
			var consoleOutSaved = Console.Out;
			using (var stream = new MemoryStream())
			{
				var writer = new StreamWriter(stream, encoding);
				Console.SetOut(writer);
				try
				{
					writer.WriteLine(s);
				}
				catch (Exception e)
				{
					Console.WriteLine($"{e.GetType().Name}: {e}");
				}
			}
			Console.SetOut(consoleOutSaved);
		}
	}
}

