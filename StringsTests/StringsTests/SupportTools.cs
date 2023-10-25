using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsTests
{
	public class SupportTools
	{
		public string BytesTitle(int sizeInBytes)
		{
			switch (sizeInBytes)
			{
				case < 1024:
					return sizeInBytes.ToString();
				case < 1048576:
					return (Math.Round(sizeInBytes / 1024.0d, 2)).ToString() + "Kb";
				default: return String.Empty;
			}

		}
	}
}
