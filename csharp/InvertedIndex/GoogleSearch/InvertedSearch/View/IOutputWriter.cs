using System.Collections.Generic;
using InvertedSearch.Models;

namespace InvertedSearch.View
{
    public interface IOutputWriter
    {
        void ShowOutput(IEnumerable<Document> docs);
    }
}