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
        static void Main(string[] args)
        {
            var jsonReader = new JsonReader<List<Person>>("/home/mohammadhosein/Desktop/Nest/csharp/ElasticSearch/ElasticSearch/ElasticHttpClient/Data/files.json");
            var postDocument = new PostDocument<Person>("nest-search");
            var client = ElasticClientFactory.GetElasticClient();
            //var customIndex = new CustomIndex(client);
            //customIndex.CreateIndex("nest-search");

            var bulk = postDocument.Post(jsonReader.ReadPerson());
            client.Bulk(bulk);
    }
    }
}
