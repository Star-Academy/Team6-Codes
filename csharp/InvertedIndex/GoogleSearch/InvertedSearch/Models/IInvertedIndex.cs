using System.Collections.Generic;

namespace InvertedSearch.Models
{
    public interface IInvertedIndex
    {
        HashSet<Document> GetDocuments(string token);
    }
}