using System;
using System.Collections.Generic;
using GoogleApp.Models;

namespace GoogleApp.View
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void ShowOutput(IEnumerable<Document> docs)
        {
            foreach (var doc in docs)
            {
                Console.WriteLine(doc.ID);
            }
        }
    }
}