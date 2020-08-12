using InvertedSearch.Models;
using Xunit;
using System.IO;

namespace GoogleSearch.Test.ModelsTest
{
    public class DocumentTest
    {
        private Document document;
        private string FilePath { get; set; }

        // prepare
        public DocumentTest()
        {
            FilePath = "../../../Data/1.txt";
            document = new Document(FilePath);
        }

        // check content of document
        [Fact]
        public void ContentDocumentsTest()
        {
            Assert.Equal("slm khobi?" , document.content);
        }

        // check document id
        [Fact]
        public void IdDocumentTest()
        {
            Assert.Equal("1.txt", document.id);
        }

        // check bad address of files
        [Fact]
        public void BadAddress()
        {
            Assert.Throws<FileNotFoundException>(() => new Document("1.txt"));
        }



    }
}