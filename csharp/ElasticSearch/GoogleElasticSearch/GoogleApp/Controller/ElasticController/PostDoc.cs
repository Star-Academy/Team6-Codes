using System;
using System.Collections.Generic;
using GoogleApp.Controller;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller.ElasticController
{
    public class PostDoc<T> where T : class
    {
        private readonly string index;

        private readonly IElasticClient client;
        public PostDoc(string index)
        {
            this.index = index;
            this.client = ElasticClientFactory.GetElasticClient();
        }

        public BulkDescriptor Post(IEnumerable<T> docs)
        {
            var bulkDescriptor = new BulkDescriptor();
            foreach (var doc in docs)
            {
                bulkDescriptor.Index<T>(x => x
                    .Index(index)
                    .Document(doc)
                );
            }
            return bulkDescriptor;
        }
    }
}
