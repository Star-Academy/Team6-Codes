using System.Collections.Generic;
using System.IO;
using InvertedSearch.Models;
using System;

namespace InvertedSearch.Controller.Repository
{
    public class FolderReader
    {
        private string folderPath { get; set; }
        public FolderReader(string folderPath)
        {
            this.folderPath = folderPath;
        }
        public HashSet<Document> DocumentsOfFolder()
        {
            HashSet<Document> documents = new HashSet<Document>();

            string[] filePaths = Directory.GetFiles(folderPath);

            Array.ForEach(filePaths, filePath => documents.Add(new Document(filePath)));

            return documents;
        }
    }
}