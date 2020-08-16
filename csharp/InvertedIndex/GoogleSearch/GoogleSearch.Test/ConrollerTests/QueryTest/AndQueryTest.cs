using System.Collections.Generic;
using InvertedSearch.Controller.Query;
using InvertedSearch.Models;
using Moq;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests.QueryTest
{
    public class AndQueryTest
    {
        private AndQuery andQuery;

        private IInvertedIndex iInvertedIndex;

        const string query = "+salam -mahdi salam mohamadhossein -chert +pert search";

        public AndQueryTest()
        {
            andQuery = new AndQuery(query);
        }

        [Fact]
        public void QueryRegexTest()
        {
            var expected = new List<string>() { "salam", "mohamadhossein", "search" };
            Assert.Equal(expected, andQuery.Queries);
        }

        private List<Document> PrepareMockDocuments(int length){

            var res = new List<Document>();

            for (int i = 0; i < length; i++)
            {
                var document = new Document(i.ToString());
                res.Add(document);
            }
            return res;

        }

        [Fact]
        public void ProcessQueryTest()
        {
            var documents = PrepareMockDocuments(4);
            var iInvertedIndexMock = new Mock<IInvertedIndex>();
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("salam"))
                .Returns(new HashSet<Document>() { documents[0], documents[1] });
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("mohamadhossein"))
                .Returns(new HashSet<Document>() { documents[1], documents[2]});
            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("search"))
                .Returns(new HashSet<Document>() { documents[1], documents[3] });
            iInvertedIndex = (IInvertedIndex)iInvertedIndexMock.Object;
            var actualResult = andQuery.ProcessQuery(iInvertedIndex);
            var expected = new HashSet<Document>() {documents[1]};
            Assert.Equal(expected, actualResult);
        }
    }
}