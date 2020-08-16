using System.Collections.Generic;

namespace InvertedSearch.Models
{

    public class InvertedIndex : IInvertedIndex
    {
        public Dictionary<string, IndexedToken> invertedIndex { get; }


        public InvertedIndex()
        {
            invertedIndex = new Dictionary<string, IndexedToken>();
        }

        public void AddIndexedToken(IEnumerable<string> tokens, Document doc)
        {
            foreach (var token in tokens)
            {
                if (!invertedIndex.ContainsKey(token))
                {
                    invertedIndex.Add(token, new IndexedToken(token));
                }
                invertedIndex[token].AddIndex(doc);

            }
        }

        public HashSet<Document> GetDocuments(string token)
        {
            if (invertedIndex.TryGetValue(token, out var indexedToken))
                return indexedToken.Indexes;
            return null;
        }
    }
}