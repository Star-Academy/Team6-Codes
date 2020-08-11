using System.IO;

namespace InvertedSearch.Models
{
    public class Document
    {
        public string id { get; }
        public string filePath { get; }

        public string content { get; }

        public Document(string filePath)
        {
            this.id = Path.GetFileName(filePath);
            this.filePath = filePath;
            this.content = File.ReadAllText(filePath);
        }
    }
}