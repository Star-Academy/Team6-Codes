using System;
using Nest;
using ElasticNest.Utils;
using ElasticNest.Models;
using System.Collections.Generic;
using ElasticNest.Controller;

namespace ElasticNest
{
    class Program
    {
        private readonly static string index = "nest-search";
        static void Main(string[] args)
        {
            // var jsonReader = new JsonReader<List<Person>>("Data/files.json");
            // var postDocument = new PostDocument<Person>(index);
            // var client = ElasticClientFactory.GetElasticClient();
            // var customIndex = new CustomIndex(client);
            // customIndex.CreateIndex(index);
            // var bulk = postDocument.Post(jsonReader.ReadPerson());
            // client.Bulk(bulk);
            CheckQuery();
        }

        static void CheckQuery()
        {
            var q = Query.TermsAggregationQuery(index);
            Console.WriteLine(q.IsValid);
            Console.WriteLine(q.ServerError);
            Console.WriteLine(q.Aggregations.Average("avg").Value);
        }

    }
}
