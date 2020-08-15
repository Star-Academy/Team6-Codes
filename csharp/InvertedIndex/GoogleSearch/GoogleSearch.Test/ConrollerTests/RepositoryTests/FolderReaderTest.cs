using System.Collections.Generic;
using InvertedSearch.Controller.Repository;
using InvertedSearch.Models;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests.RepositoryTests
{
    public class FolderReaderTest
    {

        public string folderPath { get; set; }

        public FolderReader folderReader;

        public FolderReaderTest()
        {
            folderPath = "../../../Data";
            folderReader = new FolderReader(folderPath);
        }

        [Fact]
        public void DocumentsOfFolderTest()
        {
            HashSet<Document> docs = new HashSet<Document>() { new Document(folderPath + "/3"), new Document(folderPath + "/2"), new Document(folderPath + "/1") };

            Assert.Equal(docs, folderReader.DocumentsOfFolder());
        }
    }
}