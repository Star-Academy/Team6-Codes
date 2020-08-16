using System.Collections.Generic;
using System.IO;
using InvertedSearch.Models;

namespace InvertedSearch.Controller.Repository
{
    public class FileReader : IRepositoryReader
    {

        private Document document;
        public FileReader(Document document)
        {
            this.document = document;
        }

        public HashSet<string> GetAllTokens()
        {
            var content = File.ReadAllText(document.FilePath);
            var splittedContent = content.ToLower().Split(' ');
            return new HashSet<string>(splittedContent);
        }

    }
}