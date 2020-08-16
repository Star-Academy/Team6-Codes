
using InvertedSearch.Controller.Repository;
using Xunit;
using InvertedSearch.Models;
using System.IO;

namespace GoogleSearch.Test.ConrollerTests.RepositoryTests
{

    public class FileReaderTest
    {
        private FileReader fileReader;
        private const string path = "../../../Data/1";
        public FileReaderTest()
        {
            var doc = CreateDoc();
            fileReader = new FileReader(doc);
        }
        public Document CreateDoc()
        {
            var document = new Document(path);
            return document;
        }

        [Fact]
        public void GetContentTest()
        {
            var tokens = "slm khobi";
            Assert.Equal(tokens, fileReader.GetContent());
        }

        // check bad address of files
        [Fact]
        public void BadAddress()
        {
            var reader = new FileReader(new Document("1"));
            Assert.Throws<FileNotFoundException>(() => reader.GetContent());
        }
    }
}