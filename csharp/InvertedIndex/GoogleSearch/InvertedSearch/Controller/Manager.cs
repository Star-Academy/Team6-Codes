using System.Collections.Generic;
using InvertedSearch.Controller.Query;
using InvertedSearch.Controller.Repository;
using InvertedSearch.Models;
using InvertedSearch.View;

namespace InvertedSearch.Controller
{
    public class Manager
    {

        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;
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
                var fileReader = new FileReader(doc);
                HashSet<string> tokens = new Tokenizer(fileReader.GetContent()).Tokenize();
                invertedIndex.AddIndexedToken(tokens, doc);
            }
            var query = new QueryManager(inputReader.GetQuery(), invertedIndex);
            result = query.QueryProcess();
            outputWriter.ShowOutput(result);
        }

    }
}