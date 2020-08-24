using Nest;
using System.IO;
namespace GoogleApp.Models
{
    public class Document
    {
        public readonly string ID;

        public string Content { get; set; }


        [Ignore]
        public string FilePath { get; set; }

        public Document(string filePath)
        {
            this.FilePath = filePath;
            ID = Path.GetFileName(filePath);
        }

        public Document(string id , string content){
            this.ID = id;
            this.Content = content;
            this.FilePath = id;
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