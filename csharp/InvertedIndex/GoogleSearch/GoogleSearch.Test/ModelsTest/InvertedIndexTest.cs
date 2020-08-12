using System.Collections.Generic;
using InvertedSearch.Models;
using Xunit;
using System.Linq;

namespace GoogleSearch.Test.ModelsTest
{
    public class InvertedIndexTest
    {
        private InvertedIndex invertedIndexObject;
        private Dictionary<string, IndexedToken> invertedIndexExpectedTokens;
        private string firstFileName = "1";
        private string secondFileName = "2";
        private string[] firstTokenStrings = new string[] { "salam", "khubi" };
        private string[] secondTokenStrings = new string[] { "salam" };

        private HashSet<string> firstTokens;
        private HashSet<string> secondTokens;

        public InvertedIndexTest()
        {
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
            salamToken.AddIndex(firstFileName);
            salamToken.AddIndex(secondFileName);
            khubiToken.AddIndex(firstFileName);
            invertedIndexExpectedTokens.Add("salam", salamToken);
            invertedIndexExpectedTokens.Add("khubi", khubiToken);
        }


        [Fact]
        public void AddIndexedTokenTest()
        {
            invertedIndexObject.AddIndexedToken(firstTokens, "1");
            invertedIndexObject.AddIndexedToken(secondTokens, "2");
            Assert.Equal(invertedIndexExpectedTokens, invertedIndexObject.invertedIndex);
        }
    }
}