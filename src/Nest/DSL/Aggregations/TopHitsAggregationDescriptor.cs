using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeConverter<TopHitsAggregator>))]
	public interface ITopHitsAggregator : IBucketAggregator
	{
        [JsonProperty(PropertyName = "from")]
        int? From { get; set; }

        [JsonProperty(PropertyName = "size")]
        int? Size { get; set; }

        [JsonProperty(PropertyName = "explain")]
        bool? Explain { get; set; }

        [JsonProperty(PropertyName = "sort")]
        [JsonConverter(typeof(SortCollectionConverter))]
        IList<KeyValuePair<PropertyPathMarker, ISort>> Sort { get; set; }

        [JsonProperty(PropertyName = "highlight")]
        IHighlightRequest Highlight { get; set; }

        [JsonProperty(PropertyName = "script_fields")]
        [JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
        IDictionary<string, IScriptFilter> ScriptFields { get; set; }

        [JsonProperty(PropertyName = "_source")]
        ISourceFilter Source { get; set; }

        [JsonProperty(PropertyName = "query")]
        [JsonConverter(typeof(CompositeJsonConverter<ReadAsTypeConverter<QueryContainer>, CustomJsonConverter>))]
        IQueryContainer Query { get; set; }

        [JsonProperty(PropertyName = "filter")]
        [JsonConverter(typeof(CompositeJsonConverter<ReadAsTypeConverter<FilterContainer>, CustomJsonConverter>))]
        IFilterContainer Filter { get; set; }
	}

    public class TopHitsAggregator : BucketAggregator, ITopHitsAggregator
	{
        public int? From { get; set; }

        public int? Size { get; set; }

        public bool? Explain { get; set; }

        public IList<KeyValuePair<PropertyPathMarker, ISort>> Sort { get; set; }

        public IHighlightRequest Highlight { get; set; }

        public IDictionary<string, IScriptFilter> ScriptFields { get; set; }

        public ISourceFilter Source { get; set; }

        public IQueryContainer Query { get; set; }

        public IFilterContainer Filter { get; set; }

    }


    public class TopHitsAggregationDescriptor<T> : BucketAggregationBaseDescriptor<TopHitsAggregationDescriptor<T>, T>, ITopHitsAggregator where T : class
	{
        private ITopHitsAggregator Self { get { return this; } }

        int? ITopHitsAggregator.Size { get; set; }

        public TopHitsAggregationDescriptor<T> Size(int size)
        {
            Self.Size = size;
            return this;
        }

        int? ITopHitsAggregator.From { get; set; }

        bool? ITopHitsAggregator.Explain { get; set; }

        IList<KeyValuePair<PropertyPathMarker, ISort>> ITopHitsAggregator.Sort { get; set; }

        IHighlightRequest ITopHitsAggregator.Highlight { get; set; }

        IDictionary<string, IScriptFilter> ITopHitsAggregator.ScriptFields { get; set; }

        ISourceFilter ITopHitsAggregator.Source { get; set; }

        IQueryContainer ITopHitsAggregator.Query { get; set; }

        IFilterContainer ITopHitsAggregator.Filter { get; set; }
    }
}