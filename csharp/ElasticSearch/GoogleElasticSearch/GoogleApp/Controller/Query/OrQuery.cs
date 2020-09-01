using System.Collections.Generic;
using System.Text.RegularExpressions;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller.Query
{
    public class OrQuery : QueryType
    {
        public OrQuery(string query) : base(query)
        {
            this.QueryRegex = new Regex(@"\+(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            this.QueryParser(query, 1);
        }

        public override QueryContainer ProcessQuery(IInvertedIndex invertedIndex)
        {
            var orQuery = new QueryContainer();
            foreach (var query in this.Queries){
                orQuery = orQuery || invertedIndex.GetTokenQueryContainer(query);
            }
            return orQuery;
        }
    }
}