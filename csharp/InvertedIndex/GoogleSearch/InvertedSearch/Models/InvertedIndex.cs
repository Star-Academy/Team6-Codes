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

        public void AddIndexedToken(HashSet<string> tokens, Document doc)
        {
            foreach (string token in tokens)
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
            if (invertedIndex.ContainsKey(token))
            {
                return invertedIndex[token].indexes;
            }
            else
            {
                return null;
            }
        }
    }
}