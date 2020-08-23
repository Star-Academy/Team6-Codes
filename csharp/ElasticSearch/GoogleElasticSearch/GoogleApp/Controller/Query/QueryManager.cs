using System.Collections.Generic;
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
        private readonly ElasticClient client = ElasticClientFactory.GetElasticClient();

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

            resultQuery &= AndQuery.ProcessQuery(invertedIndex);

            resultQuery |= OrQuery.ProcessQuery(invertedIndex);

            resultQuery &= DeleteQuery.ProcessQuery(invertedIndex);

            ISearchResponse<Document> response = client.Search<Document>(s => s
                .Index(index)
                .Size(1000)
                .Query(q => resultQuery));
            new ResponseValidator<ISearchResponse<Document>>(response);
            return response.Documents;
        }
    }
}