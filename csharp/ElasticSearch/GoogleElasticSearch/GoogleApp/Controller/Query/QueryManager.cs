using System.Collections.Generic;
using GoogleApp.Models;

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

        public HashSet<Document> QueryProcess()
        {
            var result = new HashSet<Document>();

            result.UnionWith(AndQuery.ProcessQuery(invertedIndex));
            
            result.UnionWith(OrQuery.ProcessQuery(invertedIndex));

            result.ExceptWith(DeleteQuery.ProcessQuery(invertedIndex));

            return result;
        }
    }
}