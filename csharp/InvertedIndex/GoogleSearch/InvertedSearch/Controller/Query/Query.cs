using System.Collections.Generic;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Query
{
    public class Query
    {
        private IInvertedIndex invertedIndex;
        private string query;

        public AndQuery andQuery { get; }

        public OrQuery orQuery { get; }
        public DeleteQuery deleteQuery { get; }

        public Query(string query, IInvertedIndex invertedIndex)
        {
            this.query = query;
            this.invertedIndex = invertedIndex;
            this.andQuery = new AndQuery(query);
            this.orQuery = new OrQuery(query);
            this.deleteQuery = new DeleteQuery(query);
        }

        public HashSet<Document> QueryProcess()
        {
            HashSet<Document> result = new HashSet<Document>();

            result.UnionWith(andQuery.ProcessQuery(invertedIndex));

            result.UnionWith(orQuery.ProcessQuery(invertedIndex));

            result.ExceptWith(deleteQuery.ProcessQuery(invertedIndex));

            return result;
        }
    }
}