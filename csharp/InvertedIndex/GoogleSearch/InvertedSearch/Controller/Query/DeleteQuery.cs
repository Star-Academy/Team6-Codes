using System.Collections.Generic;
using InvertedSearch.Models;
using System.Text.RegularExpressions;


namespace InvertedSearch.Controller.Query
{
    public class DeleteQuery : QueryType
    {
        public DeleteQuery(string query) : base(query)
        {
            this.QueryRegex = new Regex(@"\-(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            this.QueryParser(query, 1);
        }

        public override HashSet<Document> ProcessQuery(IInvertedIndex invertedIndex)
        {
            var result = new HashSet<Document>();
            foreach (var query in this.Queries)
            {
                result.UnionWith(invertedIndex.GetDocuments(query));
            }
            return result;
        }
    }
}