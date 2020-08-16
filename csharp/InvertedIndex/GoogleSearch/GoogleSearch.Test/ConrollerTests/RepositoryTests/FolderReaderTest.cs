using System.Collections.Generic;
using InvertedSearch.Controller.Repository;
using InvertedSearch.Models;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests.RepositoryTests
{
    public class FolderReaderTest
    {
        private const string folderPath = "../../../Data";
        private FolderReader folderReader;
        public FolderReaderTest()
        {
            folderReader = new FolderReader(folderPath);
        }

        [Fact]
        public void DocumentsOfFolderTest()
        {
            var docs = new HashSet<Document>() { new Document(folderPath + "/3"), new Document(folderPath + "/2"), new Document(folderPath + "/1") };
            Assert.Equal(docs, folderReader.DocumentsOfFolder());
        }
    }
}