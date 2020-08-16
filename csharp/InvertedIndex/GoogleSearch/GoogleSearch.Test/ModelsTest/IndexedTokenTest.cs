using System.Collections.Generic;
using InvertedSearch.Models;
using Xunit;
using Moq;
namespace GoogleSearch.Test.ModelsTest
{
    public class IndexedTokenTest
    {
        private IndexedToken token;
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
            Assert.Single(token.Indexes, doc);
        }

        [Fact]
        public void EqualTest()
        {
            Assert.True(token.Equals(new IndexedToken(tokenName)));
        }

        [Fact]
        public void HashCodeTest()
        {
            var tokenSet = new HashSet<IndexedToken>(){token};
            Assert.True(tokenSet.Contains(new IndexedToken(tokenName)));
        }
    }

}