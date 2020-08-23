using System.Collections.Generic;
using Nest;

namespace GoogleApp.Models
{
    public interface IInvertedIndex
    {
        QueryContainer GetDocuments(string token);
    }
}