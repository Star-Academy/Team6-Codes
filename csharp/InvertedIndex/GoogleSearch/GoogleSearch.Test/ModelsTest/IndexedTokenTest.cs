using System.Collections.Generic;
using InvertedSearch.Models;
using Xunit;
using Moq;
namespace GoogleSearch.Test.ModelsTest
{
    public class IndexedTokenTest
    {
        private IndexedToken token { get; set; }
        private Document doc;
        private string tokenName;

        public IndexedTokenTest()
        {
            tokenName = "mohamad";
            doc = new Mock<Document>().Object;
            token = new IndexedToken(tokenName);
        }

        [Fact]
        public void IndexTest()
        {
            token.AddIndex(doc);
            Assert.Single(token.indexes, doc);
        }

        [Fact]
        public void EqualTest()
        {
            Assert.True(token.Equals(new IndexedToken(tokenName)));
        }

        [Fact]
        public void HashCodeTest()
        {
            HashSet<IndexedToken> tokenSet = new HashSet<IndexedToken>();
            tokenSet.Add(token);
            Assert.True(tokenSet.Contains(new IndexedToken(tokenName)));
        }
    }

}