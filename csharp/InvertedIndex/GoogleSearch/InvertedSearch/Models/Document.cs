using System.Collections.Generic;
using System.IO;

namespace InvertedSearch.Models
{
    public class Document
    {
        public virtual string Id { get; set; }
        public virtual string FilePath { get; set; }

       public Document() { }
        public Document(string filePath)
        {
            this.Id = Path.GetFileName(filePath);
            this.FilePath = filePath;
        }

        public override int GetHashCode()
        {
            return FilePath.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Document document &&
                   FilePath == document.FilePath;
        }
    }
}