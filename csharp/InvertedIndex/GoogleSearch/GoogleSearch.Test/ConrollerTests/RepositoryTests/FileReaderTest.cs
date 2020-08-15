
using InvertedSearch.Controller.Repository;
using Xunit;
using Moq;
using InvertedSearch.Models;
using System.Collections.Generic;


namespace GoogleSearch.Test.ConrollerTests.RepositoryTests
{

    public class FileReaderTest
    {
        private FileReader fileReader { get; set; }
        private string fileContent = "hello world";
        private string fileId = "TestFile";

        public FileReaderTest()
        {
            var doc = CreateDoc();
            fileReader = new FileReader(doc);
        }
        public Document CreateDoc()
        {
            var document = new Mock<Document>();
            document.SetupAllProperties();
            document.Object.content = fileContent;
            document.Object.id = fileId;
            return document.Object;
        }

        [Fact]
        public void getAllTokensTest()
        {
            HashSet<string> tokens = new HashSet<string>();
            tokens.Add("hello");
            tokens.Add("world");
            Assert.Equal(tokens, fileReader.getAllTokens());

        }
    }
}