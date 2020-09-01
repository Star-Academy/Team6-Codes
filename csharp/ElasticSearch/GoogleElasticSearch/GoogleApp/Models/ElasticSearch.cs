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

        public QueryContainer GetTokenQueryContainer(string token)
        {
            
            QueryContainer matchQuery = new MatchQuery
            {
                Field = "content",
                Query = token,
                Fuzziness = Fuzziness.Auto
            };
            return matchQuery;
        }
    }
}