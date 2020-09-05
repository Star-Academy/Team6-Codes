using System.Collections.Generic;
using GoogleApp.Models;

namespace SearchApi.Services
{
    public interface ISearchService
    {
          IEnumerable<Document> SearchQuery(string query);
    }
}