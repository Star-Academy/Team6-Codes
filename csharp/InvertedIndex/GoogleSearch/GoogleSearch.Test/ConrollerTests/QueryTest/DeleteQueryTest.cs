using System.Collections.Generic;
using InvertedSearch.Controller.Query;
using InvertedSearch.Models;
using Moq;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests.QueryTest
{
    public class DeleteQueryTest
    {
        private DeleteQuery deleteQuery;

        private IInvertedIndex iInvertedIndex;

        const string query = "+salam -mahdi salam mohamadhossein -chert +pert search";

        public DeleteQueryTest()
        {
            deleteQuery = new DeleteQuery(query);
        }
        public List<Document> PrepareMockDocuments(int len)
        {
            var docs = new List<Document>() { };
            for (int i = 0; i < len; i++)
            {
                var docMock = new Document(i.ToString());
                docs.Add(docMock);
            }
            return docs;

        }


        [Fact]
        public void QueryRegexTest()
        {
            var expected = new List<string>() { "mahdi", "chert" };
            deleteQuery = new DeleteQuery(query);
            Assert.Equal(expected, deleteQuery.queries);
        }
        [Fact]
        public void ProcessQueryTest()
        {
            var iInvertedIndexMock = new Mock<IInvertedIndex>();
            var docs = PrepareMockDocuments(3);
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("mahdi"))
                .Returns(new HashSet<Document>() { docs[0] });
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("chert"))
                .Returns(new HashSet<Document>() { docs[1], docs[2] });
            iInvertedIndex = (IInvertedIndex)iInvertedIndexMock.Object;
            var actualResult = deleteQuery.ProcessQuery(iInvertedIndex);
            var expected = new HashSet<Document>(docs);
            Assert.Equal(expected, actualResult);

        }
    }
}