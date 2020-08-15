using System.Collections.Generic;
using InvertedSearch.Controller.Query;
using InvertedSearch.Models;
using Moq;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests.QueryTest
{
    public class QueryTest
    {

        string queryText = "+salam -mahdi salam mohamadhossein -chert +pert search";

        IInvertedIndex iInvertedIndex;

        Query query;

        public List<Document> PrepareMockDocuments(int len)
        {
            var docs = new List<Document>() { };
            for (int i = 0; i < len; i++)
            {
                var docMock = new Mock<Document>();

                docMock.SetupAllProperties();
                docMock.Object.filePath = i.ToString();
                docs.Add(docMock.Object);
            }
            return docs;
        }


        [Fact]
        public void QueryProcessTest()
        {
            List<Document> documents = PrepareMockDocuments(3);

            var iInvertedIndexMock = new Mock<IInvertedIndex>();

            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("salam"))
            .Returns(new HashSet<Document>() { documents[0], documents[1] });



            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("mahdi"))
            .Returns(new HashSet<Document>() { documents[0] });


            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("chert"))
            .Returns(new HashSet<Document>() { documents[0] });


            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("mohamadhossein"))
            .Returns(new HashSet<Document>() { documents[1], documents[2] });


            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("pert"))
            .Returns(new HashSet<Document>() { documents[1], documents[2] });


            iInvertedIndexMock.Setup(invertedIndex => invertedIndex.GetDocuments("search"))
            .Returns(new HashSet<Document>() { documents[0], documents[1] });


            iInvertedIndex = (IInvertedIndex)iInvertedIndexMock.Object;


            query = new Query(queryText, iInvertedIndex);

            var expected = new HashSet<Document>() { documents[1], documents[2] };

            var actualResult = query.QueryProcess();

            Assert.Equal(expected, actualResult);


        }



    }
}