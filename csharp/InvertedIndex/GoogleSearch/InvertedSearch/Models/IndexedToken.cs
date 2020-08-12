using System.Collections.Generic;

namespace InvertedSearch.Models
{
    public class IndexedToken
    {
        public string token { get; }
        public HashSet<string> indexes { get; }

        public IndexedToken(string token)
        {
            this.token = token;
            this.indexes = new HashSet<string>();
        }

        public void AddIndex(string index)
        {
            this.indexes.Add(index);
        }

        public override bool Equals(object obj)
        {
            return this.token.Equals(((IndexedToken)obj).token);
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