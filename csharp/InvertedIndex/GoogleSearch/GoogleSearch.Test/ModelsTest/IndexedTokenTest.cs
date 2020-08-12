using System.Collections.Generic;
using InvertedSearch.Models;
using Xunit;
namespace GoogleSearch.Test.ModelsTest
{
    public class IndexedTokenTest
    {
        private IndexedToken token { get; set; }
        private string fileName;
        private string tokenName;

        public IndexedTokenTest()
        {
            tokenName = "mohamad";
            fileName = "1";
            token = new IndexedToken(tokenName);
        }

        [Fact]
        public void IndexTest()
        {
            token.AddIndex(fileName);
            Assert.Single(token.indexes, fileName);
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