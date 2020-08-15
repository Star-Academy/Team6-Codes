using System.Collections.Generic;
using InvertedSearch.Controller.Query;
using InvertedSearch.Controller.Repository;
using InvertedSearch.Models;
using InvertedSearch.View;

namespace InvertedSearch.Controller
{
    public class Manager
    {

        private IInputReader inputReader { get; }
        private IOutputWriter outputWriter { get; }
        public HashSet<Document> result { get; set; }
        public Manager(IInputReader inputReader, IOutputWriter iOutputWriter)
        {
            this.inputReader = inputReader;
            this.outputWriter = iOutputWriter;
        }

        public void Run()
        {
            var folderReader = new FolderReader(inputReader.GetPath());
            var documents = folderReader.DocumentsOfFolder();
            var invertedIndex = new InvertedIndex();
            foreach (Document doc in documents)
            {
                FileReader fileReader = new FileReader(doc);
                invertedIndex.AddIndexedToken(fileReader.GetAllTokens(), doc);
            }

            var query = new QueryManager(inputReader.GetQuery(), invertedIndex);
            result = query.QueryProcess();
            // outputWriter.ShowOutput(result);

        }

    }
}