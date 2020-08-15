using System.Collections.Generic;
using System.IO;

namespace InvertedSearch.Models
{
    public class Document
    {
        public virtual string id { get; set; }
        public virtual string filePath { get; set; }

        public string content { get; set; }

        public Document() { }
        public Document(string filePath)
        {
            this.id = Path.GetFileName(filePath);
            this.filePath = filePath;
            this.content = File.ReadAllText(filePath);
        }

        public override int GetHashCode()
        {
            return filePath.GetHashCode();
        }
    }
}