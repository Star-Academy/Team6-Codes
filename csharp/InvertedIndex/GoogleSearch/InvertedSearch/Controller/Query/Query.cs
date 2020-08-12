using System.Collections.Generic;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Query
{
    public class Query
    {
        private InvertedIndex invertedIndex;
        private string query;
        public Query(string query , InvertedIndex invertedIndex){
            this.query = query;
            this.invertedIndex = invertedIndex;
        }
        
    }
}