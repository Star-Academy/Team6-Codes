using System;
using System.Collections.Generic;
using ElasticNest.Controller;
using ElasticNest.Models;
using Nest;

namespace ElasticNest.Utils
{
    public class PostDocument<T> where T : class
    {
        private readonly string index;

        private readonly IElasticClient client;
        public PostDocument(string index)
        {
            this.index = index;
            this.client = ElasticClientFactory.GetElasticClient();
        }

        public BulkDescriptor Post(IEnumerable<T> docs)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var doc in docs)
            {
                Console.WriteLine(doc);
                bulkDescriptor.Index<T>(x => x
                    .Index(index)
                    .Document(doc)
                );
            }
            return bulkDescriptor;
        }
    }
}
