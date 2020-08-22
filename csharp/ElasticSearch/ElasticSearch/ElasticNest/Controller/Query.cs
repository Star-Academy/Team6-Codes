using System;
using System.Collections.Generic;
using ElasticNest.Models;
using Elasticsearch.Net;
using Nest;

namespace ElasticNest.Controller
{
    public class Query
    {
        private static readonly ElasticClient client = ElasticClientFactory.GetElasticClient();

        public static ISearchResponse<Person> MatchQuery(string query, string index)
        {
            QueryContainer matchQuery = new MatchQuery
            {
                Field = "name",
                Query = query
            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => matchQuery));
        }
        public static ISearchResponse<Person> FuzzyQuery(string query, string index)
        {
            QueryContainer fuzzyQuery = new MatchQuery
            {
                Field = "name",
                Query = query,
                Fuzziness = Fuzziness.Auto
            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => fuzzyQuery));
        }
        public static ISearchResponse<Person> TermQuery(string query, string index)
        {
            QueryContainer termQuery = new TermQuery
            {
                Field = "gender",
                Value = query

            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => termQuery));
        }
        public static ISearchResponse<Person> TermsQuery(string[] query, string index)
        {
            QueryContainer termsQuery = new TermsQuery
            {
                Field = "name",
                Terms = query
            };

            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => termsQuery));
        }
        public static ISearchResponse<Person> RangeQuery(int lt, int gte, string index)
        {
            QueryContainer rangeQuery = new NumericRangeQuery
            {
                GreaterThanOrEqualTo = gte,
                LessThan = lt,
                Field = "age"
            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => rangeQuery));
        }
        public static ISearchResponse<Person> GeoQuery(double x, double y, int distance, string index)
        {
            QueryContainer geoQuery = new GeoDistanceQuery
            {
                Field = "location",
                DistanceType = GeoDistanceType.Plane,
                Location = new GeoLocation(x, y),
                Distance = distance.ToString()
            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => geoQuery));
        }
        public static ISearchResponse<Person> MultiMatchQuery(string query, string index)
        {
            QueryContainer multiMatchQuery = new MultiMatchQuery
            {
                Fields = new string[] { "name", "email" },
                Query = query,
                Operator = Operator.And
            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => multiMatchQuery));
        }
        public static ISearchResponse<Person> BoolQuery(string query, string index)
        {
            QueryContainer boolQuery = new BoolQuery
            {
                Must = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = "name",
                        Query = query
                    }
                }

            };
            return client.Search<Person>(s => s
            .Index(index)
            .Query(q => boolQuery));
        }
        public static ISearchResponse<Person> TermsAggregationQuery(string index)
        {
            return client.Search<Person>(a => a
            .Index(index)
            .Size(0)
            .Aggregations(agg => agg
                .Average("avg", avg => avg
                    .Field(p => p.Age))));

        }



    }
}