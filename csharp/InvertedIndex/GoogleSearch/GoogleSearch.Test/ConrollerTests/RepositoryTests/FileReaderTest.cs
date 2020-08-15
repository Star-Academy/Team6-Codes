
using InvertedSearch.Controller.Repository;
using Xunit;
using Moq;
using InvertedSearch.Models;
using System.Collections.Generic;
using System.IO;

namespace GoogleSearch.Test.ConrollerTests.RepositoryTests
{

    public class FileReaderTest
    {
        private FileReader fileReader { get; set; }
        private string path = "../../../Data/1";
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
        public void GetAllTokensTest()
        {
            HashSet<string> tokens = new HashSet<string>();
            tokens.Add("slm");
            tokens.Add("khobi");
            Assert.Equal(tokens, fileReader.GetAllTokens());

        }

        // check bad address of files
        [Fact]
        public void BadAddress()
        {
            var reader = new FileReader(new Document("1"));
            Assert.Throws<FileNotFoundException>(() => reader.GetAllTokens());
        }
    }
}