using System.Collections.Generic;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Repository
{
    public interface IRepositoryReader
    {
        HashSet<string> GetAllTokens();
    }
}