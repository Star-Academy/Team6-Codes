using System.Collections.Generic;

namespace InvertedSearch.Models
{
    public class InvertedIndex
    {
        public Dictionary<string, IndexedToken> invertedIndex { get; }


        public InvertedIndex()
        {
            invertedIndex = new Dictionary<string, IndexedToken>();
        }

        public void AddIndexedToken(HashSet<string> tokens, string fileName)
        {
            foreach (string token in tokens)
            {
                if (!invertedIndex.ContainsKey(token))
                {
                    invertedIndex.Add(token, new IndexedToken(token));
                }
                invertedIndex[token].AddIndex(fileName);

            }
        }


    }
}