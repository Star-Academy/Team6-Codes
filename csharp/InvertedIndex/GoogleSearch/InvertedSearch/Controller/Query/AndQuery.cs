using System.Collections.Generic;
using System.Text.RegularExpressions;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Query
{
    public class AndQuery : QueryType
    {

        public AndQuery(string query) : base(query)
        {
            this.QueryRegex = new Regex(@"([^\+\-\w]|^)(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            this.QueryParser(query, 2);
        }

        public override HashSet<Document> ProcessQuery(IInvertedIndex invertedIndex)
        {
            var result = new HashSet<Document>();
            result.UnionWith(invertedIndex.GetDocuments(queries[0]));
            for (int i = 1; i < queries.Count; i++)
            {
                result.IntersectWith(invertedIndex.GetDocuments(queries[i]));
            }
            return result;
        }
    }
}