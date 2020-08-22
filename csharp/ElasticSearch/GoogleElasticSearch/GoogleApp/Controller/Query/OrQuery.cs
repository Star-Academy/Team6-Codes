using System.Collections.Generic;
using System.Text.RegularExpressions;
using GoogleApp.Models;

namespace GoogleApp.Controller.Query
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
            foreach (var query in this.Queries){
                result.UnionWith(invertedIndex.GetDocuments(query));
            }
            return result;
        }
    }
}