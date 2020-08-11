using InvertedSearch.Models;
using Xunit;


namespace GoogleSearch.Test.ModelsTest
{
    public class DocumentTest
    {
        private Document document;
        private string FilePath { get; set; }
        public DocumentTest()
        {
            FilePath = "csharp/InvertedIndex/GoogleSearch/GoogleSearch.Test/data/1.txt";
            document = new Document(FilePath);
        }

        [Fact]
        public void ContentDocumentsTest()
        {
            Assert.Equals(document.content, "slm khobi?");
        }

        // check bad address of files


    }
}