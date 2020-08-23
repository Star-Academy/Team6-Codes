using System.Collections.Generic;
using System.Text.RegularExpressions;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller.Query
{
    public class DeleteQuery : QueryType
    {
        public DeleteQuery(string query) : base(query)
        {
            this.QueryRegex = new Regex(@"\-(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            this.QueryParser(query, 1);
        }

        public override QueryContainer ProcessQuery(IInvertedIndex invertedIndex)
        {
            var delQuery = new QueryContainer();
            foreach (var query in this.Queries)
            {
                delQuery = delQuery || invertedIndex.GetDocuments(query);
            }
            return !delQuery;
        }
    }
}