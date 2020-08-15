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

        string query = "+salam -mahdi salam mohamadhossein -chert +pert search";

        public AndQueryTest()
        {
            andQuery = new AndQuery(query);
        }

        [Fact]
        public void QueryRegexTest()
        {
            List<string> expected = new List<string>() { "salam", "mohamadhossein", "search" };
            Assert.Equal(expected, andQuery.queries);
        }

        private List<Document> PrepareMockDocuments(int length){

            List<Document> res = new List<Document>();

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
            List<Document> documents = PrepareMockDocuments(4);


            var iInvertedIndexMock = new Mock<IInvertedIndex>();

            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("salam"))
            .Returns(new HashSet<Document>() { documents[0], documents[1] });


            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("mohamadhossein"))
            .Returns(new HashSet<Document>() { documents[1], documents[2]});

            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("search"))
            .Returns(new HashSet<Document>() { documents[1], documents[3] });

            iInvertedIndex = (IInvertedIndex)iInvertedIndexMock.Object;

            HashSet<Document> actualResult = andQuery.ProcessQuery(iInvertedIndex);
            HashSet<Document> expected = new HashSet<Document>() {documents[1]};

            Assert.Equal(expected, actualResult);
        }
    }
}