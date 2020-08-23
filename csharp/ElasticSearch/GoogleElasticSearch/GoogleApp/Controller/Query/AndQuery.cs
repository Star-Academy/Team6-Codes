using System.Collections.Generic;
using System.Text.RegularExpressions;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller.Query
{
    public class AndQuery : QueryType
    {

        public AndQuery(string query) : base(query)
        {

            this.QueryRegex = new Regex(@"(^[\+\-\w*]|^)(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            this.QueryParser(query, 2);
        }

        public override QueryContainer ProcessQuery(IInvertedIndex invertedIndex)
        {
            var andQuery = new QueryContainer();
            if (Queries.Count != 0)
            {
                andQuery = invertedIndex.GetDocuments(Queries[0]);
            }
            for (int i = 1; i < Queries.Count; i++)
            {
                andQuery = andQuery && invertedIndex.GetDocuments(Queries[i]);
            }
            return andQuery;
        }
    }
}