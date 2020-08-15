using System.Collections.Generic;
using System.IO;

namespace InvertedSearch.Models
{
    public class Document
    {
        public virtual string id { get; set; }
        public virtual string filePath { get; set; }

        public Document() { }
        public Document(string filePath)
        {
            this.id = Path.GetFileName(filePath);
            this.filePath = filePath;
        }

        public override int GetHashCode()
        {
            return filePath.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Document document &&
                   filePath == document.filePath;
        }
    }
}