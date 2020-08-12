using System.Collections.Generic;
using System.IO;

namespace InvertedSearch.Models
{
    public class Document
    {
        public string id { get; set;}
        public string filePath { get; set; }

        public string content { get; set; }

        public Document(string filePath)
        {
            this.id = Path.GetFileName(filePath);
            this.filePath = filePath;
            this.content = File.ReadAllText(filePath);
        }

        public override bool Equals(object obj)
        {
            return obj is Document document &&
                   filePath == document.filePath;
        }

        public override int GetHashCode()
        {
            return filePath.GetHashCode();
        }
    }
}