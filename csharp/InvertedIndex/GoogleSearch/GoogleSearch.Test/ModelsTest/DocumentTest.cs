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
            FilePath = "../../../Data/1";
            document = new Document(FilePath);
        }

        // check document id
        [Fact]
        public void IdDocumentTest()
        {
            Assert.Equal("1", document.id);
        }

        
    }
}