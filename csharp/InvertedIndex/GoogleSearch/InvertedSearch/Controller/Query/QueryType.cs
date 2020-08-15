using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Query
{
    public abstract class QueryType
    {
        public Regex QueryRegex;
        public List<string> queries { get; }
        public QueryType(string query)
        {
            queries = new List<string>();
        }
        public abstract HashSet<Document> ProcessQuery(IInvertedIndex invertedIndex);

        public void QueryParser(string query, int group)
        {
            foreach (var match in QueryRegex.Matches(query).OfType<Match>())
                queries.Add(match.Groups[group].Value);
        }

    }
}