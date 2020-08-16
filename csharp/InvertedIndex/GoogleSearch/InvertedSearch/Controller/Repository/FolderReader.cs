using System.Collections.Generic;
using System.IO;
using InvertedSearch.Models;
using System;

namespace InvertedSearch.Controller.Repository
{
    public class FolderReader
    {
        private string folderPath;
        public FolderReader(string folderPath)
        {
            this.folderPath = folderPath;
        }
        public HashSet<Document> DocumentsOfFolder()
        {
            var documents = new HashSet<Document>();
            var filePaths = Directory.GetFiles(folderPath);
            Array.ForEach(filePaths, filePath => documents.Add(new Document(filePath)));
            return documents;
        }
    }
}