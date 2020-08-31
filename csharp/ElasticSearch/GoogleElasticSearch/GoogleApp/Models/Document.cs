using Nest;
using System.IO;
using System.Text.Json.Serialization;

namespace GoogleApp.Models
{
    public class Document
    {
        [PropertyName("id")]
        public string ID { get; set; }

        public string Content { get; set; }

        public readonly string FilePath;

        public Document(string filePath)
        {
            this.FilePath = filePath;
            ID = Path.GetFileName(filePath);
        }

        public Document(string id, string content)
        {
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