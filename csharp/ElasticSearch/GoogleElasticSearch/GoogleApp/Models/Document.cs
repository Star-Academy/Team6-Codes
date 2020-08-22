using Nest;
using System.IO;
namespace GoogleApp.Models
{
    public class Document
    {
        public readonly string Id;

        public string Content { get; set; }


        [Ignore]
        public string FilePath { get; set; }

        public Document(string filePath)
        {
            this.FilePath = filePath;
            Id = Path.GetFileName(filePath);
        }

    }
}