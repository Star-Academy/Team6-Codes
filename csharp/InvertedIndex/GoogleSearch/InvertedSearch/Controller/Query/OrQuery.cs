using System.Collections.Generic;
using System.Text.RegularExpressions;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Query
{
    public class OrQuery : QueryType
    {
        public OrQuery(string query) : base(query)
        {
            this.QueryRegex = new Regex(@"\+(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            this.QueryParser(query, 1);
        }

        public override HashSet<Document> ProcessQuery(IInvertedIndex invertedIndex)
        {
            var result = new HashSet<Document>();
            foreach (var query in this.queries){
                result.UnionWith(invertedIndex.GetDocuments(query));
            }
            return result;
        }
    }
}