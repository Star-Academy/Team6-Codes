using System.Collections.Generic;

namespace InvertedSearch.Models
{
    public class IndexedToken
    {
        private string token;
        public HashSet<Document> Indexes { get; }

        public IndexedToken(string token)
        {
            this.token = token;
            Indexes = new HashSet<Document>();
        }

        public void AddIndex(Document doc)
        {
            Indexes.Add(doc);
        }

        public override bool Equals(object obj)
        {
            return token.Equals(((IndexedToken)obj).token);
        }

        public override int GetHashCode()
        {
            return token.GetHashCode();
        }

        public override string ToString()
        {
            return token;
        }
    }
}