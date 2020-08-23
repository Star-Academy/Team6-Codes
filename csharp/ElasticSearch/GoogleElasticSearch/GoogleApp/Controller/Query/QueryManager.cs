using System;
using System.Collections.Generic;
using Elasticsearch.Net;
using GoogleApp.Controller.ElasticController;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller.Query
{
    public class QueryManager
    {
        private IInvertedIndex invertedIndex;
        private string query;

        public AndQuery AndQuery { get; }

        public OrQuery OrQuery { get; }
        public DeleteQuery DeleteQuery { get; }

        public QueryManager(string query, IInvertedIndex invertedIndex)
        {
            this.query = query;
            this.invertedIndex = invertedIndex;
            this.AndQuery = new AndQuery(query);
            this.OrQuery = new OrQuery(query);
            this.DeleteQuery = new DeleteQuery(query);
        }

        public IEnumerable<Document> QueryProcess(string index)
        {
            var resultQuery = new QueryContainer();

            resultQuery = resultQuery && AndQuery.ProcessQuery(invertedIndex);

            resultQuery = resultQuery && OrQuery.ProcessQuery(invertedIndex);

            resultQuery = resultQuery && DeleteQuery.ProcessQuery(invertedIndex);

            HashSet<Document> docs = new HashSet<Document>();

            ElasticClient client = ElasticClientFactory.GetElasticClient();
            ISearchResponse<Document> response = client.Search<Document>(s => s
                .Index(index)
                .Size(1000)
                .Query(q => resultQuery));
            return response.Documents;
        }
    }
}