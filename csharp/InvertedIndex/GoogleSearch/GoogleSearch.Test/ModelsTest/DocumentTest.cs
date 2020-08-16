using InvertedSearch.Models;
using Xunit;

namespace GoogleSearch.Test.ModelsTest
{
    public class DocumentTest
    {
        private Document document;
        private const string filePath = "../../../Data/1";
        // prepare
        public DocumentTest()
        {
            document = new Document(filePath);
        }

        // check document id
        [Fact]
        public void IdDocumentTest()
        {
            Assert.Equal("1", document.Id);
        }

        
    }
}