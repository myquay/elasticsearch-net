using System;
using System.Collections.Generic;

namespace Nest
{
	public class TopHitsItem : BucketAggregationBase, IBucketItem
	{
        public long Total { get; set; }
		public double MaxScore { get; set; }

        //TODO: Strongly type this...
        public IEnumerable<dynamic> Items { get; set; }
	}
}