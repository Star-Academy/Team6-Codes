using GoogleApp.Models;
using System.Collections.Generic;
using GoogleApp.Controller.ElasticController;
using GoogleApp.Controller.Repository;
using GoogleApp.View;
using GoogleApp.Controller.Query;
using Elasticsearch.Net;
using Nest;
using GoogleApp.Controller.Excpetion;
using System;

namespace GoogleApp.Controller
{
    public class Manager
    {
        private string index = "google-docs";

        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;
        private readonly ElasticClient client;
        public IEnumerable<Document> result { get; set; }
        private string folderPath = "Data";

        public Manager(IInputReader inputReader, IOutputWriter iOutputWriter)
        {
            this.inputReader = inputReader;
            this.outputWriter = iOutputWriter;
            client = ElasticClientFactory.GetElasticClient();
        }


        public void Run()
        {
            var import = new Importer(index);

            var isIndexed = import.CreateIndex();
            import.PostDocument(folderPath, isIndexed, true);
            ElasticSearch elasticSearch = new ElasticSearch(index);
            var query = new QueryManager(inputReader.GetQuery(), elasticSearch);
            try
            {
                result = query.QueryProcess(index);
                outputWriter.ShowOutput(result);
            }
            catch (ElasticException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}