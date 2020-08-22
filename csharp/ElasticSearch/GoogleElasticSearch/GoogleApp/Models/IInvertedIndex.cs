using System.Collections.Generic;

namespace GoogleApp.Models
{
    public interface IInvertedIndex
    {
        HashSet<Document> GetDocuments(string token);
    }
}