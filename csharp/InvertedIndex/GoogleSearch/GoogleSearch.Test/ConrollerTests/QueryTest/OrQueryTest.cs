using System.Collections.Generic;
using InvertedSearch.Controller.Query;
using InvertedSearch.Models;
using Moq;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests.QueryTest
{
    public class OrQueryTest
    {
        private OrQuery orQuery;
        private IInvertedIndex iInvertedIndex;
        const string query = "+salam -mahdi salam mohamadhossein -chert +pert search";
        public OrQueryTest()
        {
            orQuery = new OrQuery(query);
        }

        [Fact]
        public void QueryRegexTest()
        {
            var expected = new List<string>() { "salam", "pert" };
            Assert.Equal(expected, orQuery.Queries);
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
        public void ProcessQueryTest()
        {
            var documents = PrepareMockDocuments(3);
            var iInvertedIndexMock = new Mock<IInvertedIndex>();
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("salam"))
                .Returns(new HashSet<Document>() { documents[0], documents[1] });
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("pert"))
                .Returns(new HashSet<Document>() { documents[1], documents[2] });
            iInvertedIndex = (IInvertedIndex)iInvertedIndexMock.Object;
            var actualResult = orQuery.ProcessQuery(iInvertedIndex);
            var expected = new HashSet<Document>(documents);
            Assert.Equal(expected, actualResult);
        }
    }
}