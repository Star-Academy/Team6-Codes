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

        public QueryManager(string query, IInvertedIndex invertedIndex)
        {
            this.query = query;
            this.invertedIndex = invertedIndex;
            this.AndQuery = new AndQuery(query);
            this.OrQuery = new OrQuery(query);
            this.DeleteQuery = new DeleteQuery(query);
        }

        public HashSet<Document> QueryProcess(string index)
        {
            var resultQuery = new QueryContainer();

            resultQuery = resultQuery && AndQuery.ProcessQuery(invertedIndex);
            
            resultQuery = resultQuery && OrQuery.ProcessQuery(invertedIndex);

            resultQuery =  resultQuery && DeleteQuery.ProcessQuery(invertedIndex);

            HashSet<Document> docs = new HashSet<Document>();

            ElasticClient client = ElasticClientFactory.GetElasticClient();

            ISearchResponse<Document> response = client.Search<Document>(s => s
                .Index(index)
                .Size(1000)
                .Query(q => resultQuery));

            foreach(Document doc in response.Documents){
                Document document = new Document(doc.Id , doc.Content);
                docs.Add(document);
            }
            return docs;
        }
    }
}