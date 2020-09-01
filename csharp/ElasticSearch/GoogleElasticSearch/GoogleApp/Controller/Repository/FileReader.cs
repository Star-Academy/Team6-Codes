using System.IO;
using GoogleApp.Models;

namespace GoogleApp.Controller.Repository
{
    public class FileReader : IRepositoryReader
    {

        private Document document;
        public FileReader(Document document)
        {
            this.document = document;
        }

        public string GetContent()
        {
            var content = File.ReadAllText(document.FilePath);
            return content;
        }

    }
}