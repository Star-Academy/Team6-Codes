using System;
using System.Collections.Generic;
using InvertedSearch.Models;

namespace InvertedSearch.View
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void ShowOutput(IEnumerable<Document> docs)
        {
            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Id);
            }
        }
    }
}