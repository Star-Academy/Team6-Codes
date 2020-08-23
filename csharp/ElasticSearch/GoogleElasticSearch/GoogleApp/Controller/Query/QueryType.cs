using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller.Query
{
    public abstract class QueryType
    {
        protected Regex QueryRegex { get; set; }
        public List<string> Queries { get; }
        public QueryType(string query)
        {
            Queries = new List<string>();
        }
        public abstract QueryContainer ProcessQuery(IInvertedIndex invertedIndex);

        public void QueryParser(string query, int group)
        {
            foreach (var match in QueryRegex.Matches(query).OfType<Match>())
                Queries.Add(match.Groups[group].Value);
        }
    }
}