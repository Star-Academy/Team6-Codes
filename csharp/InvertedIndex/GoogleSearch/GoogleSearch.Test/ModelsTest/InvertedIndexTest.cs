using System.Collections.Generic;
using InvertedSearch.Models;
using Xunit;
using System.Linq;
using Moq;

namespace GoogleSearch.Test.ModelsTest
{
    public class InvertedIndexTest
    {
        private InvertedIndex invertedIndexObject;
        private Dictionary<string, IndexedToken> invertedIndexExpectedTokens;
        private Document firstDocument;
        private Document secondDocument;
        private string[] firstTokenStrings = new string[] { "salam", "khubi" };
        private string[] secondTokenStrings = new string[] { "salam" };

        private HashSet<string> firstTokens;
        private HashSet<string> secondTokens;

        public InvertedIndexTest()
        {

            firstDocument = new Mock<Document>().Object;
            secondDocument = new Mock<Document>().Object;
            invertedIndexObject = new InvertedIndex();
            invertedIndexExpectedTokens = new Dictionary<string, IndexedToken>();
            firstTokens = new HashSet<string>(firstTokenStrings);
            secondTokens = new HashSet<string>(secondTokenStrings);
            prepareExpectedIndexedTokens();
        }

        public void prepareExpectedIndexedTokens()
        {
            var salamToken = new IndexedToken("salam");
            var khubiToken = new IndexedToken("khubi");

            salamToken.AddIndex(firstDocument);
            salamToken.AddIndex(secondDocument);
            
            khubiToken.AddIndex(firstDocument);

            invertedIndexExpectedTokens.Add("salam", salamToken);
            invertedIndexExpectedTokens.Add("khubi", khubiToken);

            invertedIndexObject.AddIndexedToken(firstTokens, firstDocument);
            invertedIndexObject.AddIndexedToken(secondTokens, secondDocument);
        }


        [Fact]
        public void AddIndexedTokenTest()
        {
            Assert.Equal(invertedIndexExpectedTokens, invertedIndexObject.invertedIndex);
        }

        [Fact]
        public void getDocumentsTest()
        {
            
            Assert.Equal(invertedIndexExpectedTokens["salam"].indexes, invertedIndexObject.GetDocuments("salam"));
        }
    }
}