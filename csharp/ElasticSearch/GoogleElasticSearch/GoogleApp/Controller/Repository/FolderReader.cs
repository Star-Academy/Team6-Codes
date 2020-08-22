using System.Collections.Generic;
using System.IO;
using GoogleApp.Models;
using System;

namespace GoogleApp.Controller.Repository
{
    public class FolderReader
    {
        private string folderPath;
        public FolderReader(string folderPath)
        {
            this.folderPath = folderPath;
        }
        public List<Document> DocumentsOfFolder()
        {
            var documents = new List<Document>();
            var filePaths = Directory.GetFiles(folderPath);
            Array.ForEach(filePaths, filePath => documents.Add(new Document(filePath)));
            return documents;
        }
    }
}