using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHistoricalNet7_8Features.FeatureTricks
{
	public static class QueriesFun
	{
		public static void Run(TextWriter log)
		{
			// Data source.
			int[] scores = { 90, 71, 82, 93, 75, 82 };

			// Query Expression.
			IEnumerable<int> scoreQuery = //query variable
				from score in scores //required
				where score > 80 // optional
				orderby score descending // optional
				select score; //must end with select or group
			var enumerator = scoreQuery.GetEnumerator();
			while (enumerator.MoveNext()) {
			}
		}
	}
}
