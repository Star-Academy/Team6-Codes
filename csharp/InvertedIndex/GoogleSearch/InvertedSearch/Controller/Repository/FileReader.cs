using System.Collections.Generic;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Repository
{
    public class FileReader : IRepositoryReader
    {

        public Document document;
        public FileReader(Document document)
        {
            this.document = document;
        }

        public HashSet<string> getAllTokens()
        {
            var content = document.content;
            var splittedContent = content.ToLower().Split(' ');
            return new HashSet<string>(splittedContent);
        }

    }
}