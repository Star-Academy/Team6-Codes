
using InvertedSearch.Controller.Repository;
using Xunit;
using Moq;
using InvertedSearch.Models;
using System.Collections.Generic;
using Moq.Protected;

namespace GoogleSearch.Test.ConrollerTests.RepositoryTests
{

    public class FileReaderTest
    {
        public FileReaderTest(FileReader fileReader)
        {
            this.fileReader = fileReader;

        }
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
            var document = new Document("1.txt");
            var x = document.Arrange(() => document.content)
                .Returns(fileContent);
            // var document = new Mock<Document>();
            document.SetupGet(doc => doc.content).Returns(fileContent);
            document.SetupGet(doc => doc.id).Returns(fileId);


            //document.Protected().SetupGet<string>(fileContent).
            //document.Setup(doc => doc.content).Returns(fileContent);
            /* document.SetupAllProperties();
            document.Object.content = fileContent;
            document.Object.id = fileId;*/
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