using GoogleApp.Models;
using System.Collections.Generic;
using GoogleApp.Controller.ElasticController;
using GoogleApp.Controller.Repository;
using GoogleApp.View;
using GoogleApp.Controller.Query;
using Elasticsearch.Net;
using Nest;

namespace GoogleApp.Controller
{
    public class Manager
    {
        private string index = "google-docs";

        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;

        public IEnumerable<Document> result { get; set; }
        private string folderPath = "Data";

        public Manager(IInputReader inputReader, IOutputWriter iOutputWriter)
        {
            this.inputReader = inputReader;
            this.outputWriter = iOutputWriter;
        }


        public void Run()
        {
            var client = ElasticClientFactory.GetElasticClient();
            PostDocument(client);
            ElasticSearch elasticSearch = new ElasticSearch(index);
            var query = new QueryManager(inputReader.GetQuery(), elasticSearch);
            result = query.QueryProcess(index);
            outputWriter.ShowOutput(result);
        }
        public List<Document> CreateDoc()
        {
            FolderReader folderReader = new FolderReader(folderPath);
            List<Document> documents = folderReader.DocumentsOfFolder();
            foreach (Document doc in documents)
            {
                var reader = new FileReader(doc);
                doc.Content = reader.GetContent();
            }
            return documents;
        }

        public void PostDocument(ElasticClient client)
        {
            var existsIndicesResponse = client.Indices.Exists(index);
            new ResponseValidator<ExistsResponse>(existsIndicesResponse);
            if (existsIndicesResponse.Exists)
            {
                return;
            }
            var customIndex = new CustomIndex();
            customIndex.CreateIndex(index);
            List<Document> docs = CreateDoc();
            var postDocument = new PostDoc<Document>(index);
            var bulk = postDocument.Post(docs);
            var bulkResponse = client.Bulk(bulk);
            new ResponseValidator<BulkResponse>(bulkResponse);
        }
    }
}