using System;
using System.Collections.Generic;
using GoogleApp.Controller.ElasticController;
using Nest;

namespace GoogleApp.Models
{
    public class ElasticSearch : IInvertedIndex
    {

        private ElasticClient client;
        private string index;

        public ElasticSearch(string index)
        {
            client = ElasticClientFactory.GetElasticClient();
            this.index = index;
        }

        public HashSet<Document> GetDocuments(string token)
        {
            HashSet<Document> result = new HashSet<Document>();
            
            QueryContainer matchQuery = new MatchQuery
            {
                Field = "content",
                Query = token,
                Fuzziness = Fuzziness.Auto
            };

            ISearchResponse<Document> response = client.Search<Document>(s => s
                .Index(index)
                .Query(q => matchQuery));
            
            
            foreach(var doc in response.Documents)
            {
                Document d = new Document(doc.Id,doc.Content);
                result.Add(d);
            }

            return result;
        }
    }
}