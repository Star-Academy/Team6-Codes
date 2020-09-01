
using System.Collections.Generic;
using GoogleApp.Controller.Query;
using GoogleApp.Models;

namespace SearchApi.Services
{
    public class ElasticSearchService : ISearchService
    {

        private readonly string index = "google-docs";

        private readonly ElasticSearch elasticSearch;

        public ElasticSearchService()
        {
            elasticSearch = new ElasticSearch(index);
        }

        public IEnumerable<Document> SearchQuery(string query)
        {
            var queryManager = new QueryManager(query, elasticSearch);
            return queryManager.QueryProcess(index);
        }

    }
}